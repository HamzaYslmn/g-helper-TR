﻿// Source thanks to https://github.com/vddCore/Starlight with some adjustments from me

using Starlight.Communication;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;

namespace Starlight.AnimeMatrix
{
    public class BuiltInAnimation
    {
        public enum Startup
        {
            GlitchConstruction,
            StaticEmergence
        }

        public enum Shutdown
        {
            GlitchOut,
            SeeYa
        }

        public enum Sleeping
        {
            BannerSwipe,
            Starfield
        }

        public enum Running
        {
            BinaryBannerScroll,
            RogLogoGlitch
        }

        public byte AsByte { get; }

        public BuiltInAnimation(
            Running running,
            Sleeping sleeping,
            Shutdown shutdown,
            Startup startup
        )
        {
            AsByte |= (byte)(((int)running & 0x01) << 0);
            AsByte |= (byte)(((int)sleeping & 0x01) << 1);
            AsByte |= (byte)(((int)shutdown & 0x01) << 2);
            AsByte |= (byte)(((int)startup & 0x01) << 3);
        }
    }

    internal class AnimeMatrixPacket : Packet
    {
        public AnimeMatrixPacket(byte[] command)
            : base(0x5E, 640, command)
        {
        }
    }

    public enum AnimeType
    {
        GA401,
        GA402
    }



    public enum BrightnessMode : byte
    {
        Off = 0,
        Dim = 1,
        Medium = 2,
        Full = 3
    }


    public class AnimeMatrixDevice : Device
    {
        int UpdatePageLength = 490;
        int LedCount = 1450;

        byte[] _displayBuffer;
        List<byte[]> frames = new List<byte[]>();

        public int MaxRows = 61;
        //public int FullRows = 11;
        //public int FullEvenRows = -1;

        public int MaxColumns = 34;

        private int frameIndex = 0;

        private static AnimeType _model = AnimeType.GA402;

        public AnimeMatrixDevice()
            : base(0x0B05, 0x193B, 640)
        {
            string model = GetModel();
            if (model.Contains("401"))
            {

                _model = AnimeType.GA401;

                MaxColumns = 33;

                //FullRows = 7;
                //FullEvenRows = 3;

                MaxRows = 55;
                LedCount = 1214;
                UpdatePageLength = 410;
            }


            _displayBuffer = new byte[LedCount];

        }


        public string GetModel()
        {
            using (var searcher = new ManagementObjectSearcher(@"Select * from Win32_ComputerSystem"))
            {
                foreach (var process in searcher.Get())
                    return process["Model"].ToString();
            }

            return null;

        }

        public byte[] GetBuffer()
        {
            return _displayBuffer;
        }

        public void PresentNextFrame()
        {
            if (frameIndex >= frames.Count) frameIndex = 0;
            _displayBuffer = frames[frameIndex];
            Present();
            frameIndex++;
        }

        public void ClearFrames()
        {
            frames.Clear();
            frameIndex = 0;
        }

        public void AddFrame()
        {
            frames.Add(_displayBuffer.ToArray());
        }

        public void SendRaw(params byte[] data)
        {
            Set(Packet<AnimeMatrixPacket>(data));
        }


        public static int FirstX(int y)
        {
            switch (_model)
            {
                case AnimeType.GA401:
                    if (y < 5)
                    {
                        return 0;
                    }
                    else
                    {
                        return (y + 1) / 2 - 3;
                    }
                case AnimeType.GA402:
                    if (y < 11)
                    {
                        return 0;
                    } else
                    {
                        return (y) / 2 - 5;
                    }
                default:
                    throw new ArgumentException("Invalid anime type", nameof(_model));
            }
        }

        public static int Width(int y)
        {
            switch (_model)
            {
                case AnimeType.GA401:
                    return 33;
                case AnimeType.GA402:
                    return 34;
                default:
                    throw new ArgumentException("Invalid anime type", nameof(_model));
            }
        }

        public static int Pitch(int y)
        {
            switch (_model)
            {
                case AnimeType.GA401:
                    switch (y)
                    {
                        case 0:
                        case 2:
                        case 4:
                            return 33;
                        case 1:
                        case 3:
                            return 35; // Some rows are padded
                        default:
                            return 36 - y / 2;
                    }
                case AnimeType.GA402:
                    return Width(y) - FirstX(y);
                default:
                    throw new ArgumentException("Invalid anime type", nameof(_model));
            }
        }

        /*
        public int XStart(int row)
        {
            return (int)Math.Ceiling(Math.Max(0, row - FullRows) / 2.0);
        }

        public int XEnd(int row)
        {
            if (row <= FullEvenRows)
            {
                if (row % 2 == 1) return MaxColumns + 2;
                else return MaxColumns;
            }
            return MaxColumns;
        }
        */

        public int RowToLinearAddress(int y)
        {
            EnsureRowInRange(y);

            int ret = 0;

            for (var i = 0; i < y; i++)
                ret += Pitch(i);

            return ret;
        }

        public void SetLedPlanar(int x, int y, byte value)
        {
            EnsureRowInRange(y);

            if (x >= FirstX(y) && x < Width(y))
            {
                SetLedLinear(RowToLinearAddress(y) - FirstX(y) + x, value);
            }
        }

        public void WakeUp()
        {
            Set(Packet<AnimeMatrixPacket>(Encoding.ASCII.GetBytes("ASUS Tech.Inc.")));
        }

        public void SetLedLinear(int address, byte value)
        {
            if (!IsAddressableLed(address)) return;
            _displayBuffer[address] = value;
        }

        public void SetLedLinearImmediate(int address, byte value)
        {
            if (!IsAddressableLed(address)) return;
            _displayBuffer[address] = value;

            Set(Packet<AnimeMatrixPacket>(0xC0, 0x02)
                .AppendData(BitConverter.GetBytes((ushort)(address + 1)))
                .AppendData(BitConverter.GetBytes((ushort)0x0001))
                .AppendData(value)
            );

            Set(Packet<AnimeMatrixPacket>(0xC0, 0x03));
        }



        public void Clear(bool present = false)
        {
            for (var i = 0; i < _displayBuffer.Length; i++)
                _displayBuffer[i] = 0;

            if (present)
                Present();
        }

        public void Present()
        {

            int page = 0;
            int start, end;

            while (page * UpdatePageLength < LedCount)
            {
                start = page * UpdatePageLength;
                end = Math.Min(LedCount, (page + 1) * UpdatePageLength);

                Set(Packet<AnimeMatrixPacket>(0xC0, 0x02)
                    .AppendData(BitConverter.GetBytes((ushort)(start + 1)))
                    .AppendData(BitConverter.GetBytes((ushort)(end - start)))
                    .AppendData(_displayBuffer[start..end])
                );

                page++;
            }

            Set(Packet<AnimeMatrixPacket>(0xC0, 0x03));
        }

        public void SetDisplayState(bool enable)
        {
            if (enable)
            {
                Set(Packet<AnimeMatrixPacket>(0xC3, 0x01)
                    .AppendData(0x00));
            }
            else
            {
                Set(Packet<AnimeMatrixPacket>(0xC3, 0x01)
                    .AppendData(0x80));
            }
        }

        public void SetBrightness(BrightnessMode mode)
        {
            Set(Packet<AnimeMatrixPacket>(0xC0, 0x04)
                .AppendData((byte)mode)
            );
        }

        public void SetBuiltInAnimation(bool enable)
        {
            var enabled = enable ? (byte)0x00 : (byte)0x80;
            Set(Packet<AnimeMatrixPacket>(0xC4, 0x01, enabled));
        }

        public void SetBuiltInAnimation(bool enable, BuiltInAnimation animation)
        {
            SetBuiltInAnimation(enable);
            Set(Packet<AnimeMatrixPacket>(0xC5, animation.AsByte));
        }



        public void PresentText(string text, float fontSize = 8F)
        {
            using (Bitmap bmp = new Bitmap(MaxColumns * 3, MaxRows))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    using (Font font = new Font("Arial", fontSize))
                    {

                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        /*
                        SizeF textSize = g.MeasureString(text, font);
                        g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                        g.RotateTransform(33);
                        g.DrawString(text, font, Brushes.White, -textSize.Width/2, -textSize.Height / 2);
                        */

                        g.DrawString(text, font, Brushes.White, 12, -2);
                    }
                }

                GenerateFrame(bmp);
                Present();
            }

        }

        public void GenerateFrame(Image image)
        {

            int width = MaxColumns * 3;
            int height = MaxRows;
            float scale;

            using (Bitmap canvas = new Bitmap(width, height))
            {
                scale = Math.Min((float)width / (float)image.Width, (float)height / (float)image.Height);

                using (var graph = Graphics.FromImage(canvas))
                {
                    var scaleWidth = (int)(image.Width * scale);
                    var scaleHeight = (int)(image.Height * scale);

                    graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    graph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    graph.DrawImage(image, ((int)width - scaleWidth), 0, scaleWidth, scaleHeight);

                }

                using (Bitmap bmp = new Bitmap(canvas, MaxColumns * 2, MaxRows))
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                            if (x % 2 == y % 2)
                            {
                                var pixel = bmp.GetPixel(x, y);
                                SetLedPlanar(x / 2, y, (byte)((pixel.R + pixel.G + pixel.B) / 3));
                            }
                    }
                }
            }


        }

        private void EnsureRowInRange(int row)
        {
            if (row < 0 || row >= MaxRows)
            {
                throw new IndexOutOfRangeException($"Y-coordinate should fall in range of [0, {MaxRows - 1}].");
            }
        }

        private bool IsAddressableLed(int address)
        {
            return (address >= 0 && address < LedCount);
        }
    }
}