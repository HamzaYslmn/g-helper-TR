﻿using CustomControls;
using Starlight.AnimeMatrix;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
using System.Text.Json;
using System.Timers;

namespace GHelper
{

    public partial class SettingsForm : RForm
    {

        public static System.Timers.Timer aTimer = default!;
        public static Point trayPoint;

        static System.Timers.Timer matrixTimer = default!;

        public string versionUrl = "http://github.com/HamzaYslmn/g-helper-TR/releases";

        public string perfName = "Balanced";

        public Fans fans;
        public Keyboard keyb;

        static AnimeMatrixDevice mat;
        static long lastRefresh;

        public SettingsForm()
        {
            InitializeComponent();
            this.TopMost = true;
            InitTheme();

            FormClosing += SettingsForm_FormClosing;

            buttonSilent.BorderColor = colorEco;
            buttonBalanced.BorderColor = colorStandard;
            buttonTurbo.BorderColor = colorTurbo;

            buttonEco.BorderColor = colorEco;
            buttonStandard.BorderColor = colorStandard;
            buttonUltimate.BorderColor = colorTurbo;
            buttonOptimized.BorderColor = colorEco;

            button60Hz.BorderColor = SystemColors.ActiveBorder;
            button120Hz.BorderColor = SystemColors.ActiveBorder;
            buttonScreenAuto.BorderColor = SystemColors.ActiveBorder;
            buttonMiniled.BorderColor = colorTurbo;

            buttonOptimized.Click += ButtonOptimized_Click;
            buttonSilent.Click += ButtonSilent_Click;
            buttonBalanced.Click += ButtonBalanced_Click;
            buttonTurbo.Click += ButtonTurbo_Click;

            buttonEco.Click += ButtonEco_Click;
            buttonStandard.Click += ButtonStandard_Click;
            buttonUltimate.Click += ButtonUltimate_Click;

            VisibleChanged += SettingsForm_VisibleChanged;

            button60Hz.Click += Button60Hz_Click;
            button120Hz.Click += Button120Hz_Click;
            buttonScreenAuto.Click += ButtonScreenAuto_Click;
            buttonMiniled.Click += ButtonMiniled_Click;

            buttonQuit.Click += ButtonQuit_Click;

            buttonKeyboardColor.Click += ButtonKeyboardColor_Click;

            buttonFans.Click += ButtonFans_Click;
            buttonKeyboard.Click += ButtonKeyboard_Click;

            pictureColor.Click += PictureColor_Click;
            pictureColor2.Click += PictureColor2_Click;

            labelCPUFan.Click += LabelCPUFan_Click;
            labelGPUFan.Click += LabelCPUFan_Click;

            comboMatrix.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMatrixRunning.DropDownStyle = ComboBoxStyle.DropDownList;

            comboMatrix.DropDownClosed += ComboMatrix_SelectedValueChanged;
            comboMatrixRunning.DropDownClosed += ComboMatrixRunning_SelectedValueChanged;

            checkMatrix.CheckedChanged += CheckMatrix_CheckedChanged; ;

            buttonMatrix.Click += ButtonMatrix_Click;

            checkStartup.CheckedChanged += CheckStartup_CheckedChanged;

            labelVersion.Click += LabelVersion_Click;
            labelVersion.ForeColor = Color.FromArgb(128, Color.Gray);

            buttonOptimized.MouseMove += ButtonOptimized_MouseHover;
            buttonOptimized.MouseLeave += ButtonGPU_MouseLeave;

            buttonEco.MouseMove += ButtonEco_MouseHover;
            buttonEco.MouseLeave += ButtonGPU_MouseLeave;

            buttonStandard.MouseMove += ButtonStandard_MouseHover;
            buttonStandard.MouseLeave += ButtonGPU_MouseLeave;

            buttonUltimate.MouseMove += ButtonUltimate_MouseHover;
            buttonUltimate.MouseLeave += ButtonGPU_MouseLeave;

            buttonScreenAuto.MouseMove += ButtonScreenAuto_MouseHover;
            buttonScreenAuto.MouseLeave += ButtonScreen_MouseLeave;

            button60Hz.MouseMove += Button60Hz_MouseHover;
            button60Hz.MouseLeave += ButtonScreen_MouseLeave;

            button120Hz.MouseMove += Button120Hz_MouseHover;
            button120Hz.MouseLeave += ButtonScreen_MouseLeave;

            trackBattery.ValueChanged += TrackBattery_ValueChanged;
            Program.trayIcon.MouseMove += TrayIcon_MouseMove;

            //buttonStandard.Image = (Image)(new Bitmap(buttonStandard.Image, new Size(16, 16)));

            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += OnTimedEvent;

            SetVersionLabel("Sürüm: " + Assembly.GetExecutingAssembly().GetName().Version);
            Thread t = new Thread(() =>
            {
                CheckForUpdatesAsync();
            });
            t.Start();
            t.Join();

            // Subscribing for monitor power on events
            var settingGuid = new NativeMethods.PowerSettingGuid();
            Program.unRegPowerNotify = NativeMethods.RegisterPowerSettingNotification(Handle, settingGuid.ConsoleDisplayState, NativeMethods.DEVICE_NOTIFY_WINDOW_HANDLE);

        }


        private void TrackBattery_ValueChanged(object? sender, EventArgs e)
        {
            SetBatteryChargeLimit(trackBattery.Value);
        }


        public async void CheckForUpdatesAsync()
        {

            try
            {

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    var json = await httpClient.GetStringAsync("https://api.github.com/repos/HamzaYslmn/g-helper-TR/releases/latest");
                    var config = JsonSerializer.Deserialize<JsonElement>(json);
                    var tag = config.GetProperty("tag_name").ToString().Replace("v", "");
                    var url = config.GetProperty("assets")[0].GetProperty("browser_download_url").ToString();

                    Thread.Sleep(5000);

                    var gitVersion = new Version(tag);
                    var appVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());

                    if (gitVersion.CompareTo(appVersion) > 0)
                    {
                        BeginInvoke(delegate
                        {
                            SetVersionLabel("Güncelleme: " + tag, url);
                        });
                    }
                    else
                    {
                        Debug.WriteLine("Latest version");
                    }

                }
            }
            catch (Exception ex)
            {
                //Logger.WriteLine("Failed to check for updates:" + ex.Message);

            }

        }

        private static void TrayIcon_MouseMove(object? sender, MouseEventArgs e)
        {
            RefreshSensors();
        }


        private static void OnTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            RefreshSensors();
        }

        private void Button120Hz_MouseHover(object? sender, EventArgs e)
        {
            labelTipScreen.Text = "Maksimum Ekran Yenileme Hızı + OD (Gecikme Azaltma))";
        }

        private void Button60Hz_MouseHover(object? sender, EventArgs e)
        {
            labelTipScreen.Text = "Batarya Tasarrufu için 60Hz Ekran Yenileme Hızı";
        }

        private void ButtonScreen_MouseLeave(object? sender, EventArgs e)
        {
            labelTipScreen.Text = "";
        }

        private void ButtonScreenAuto_MouseHover(object? sender, EventArgs e)
        {
            labelTipScreen.Text = "Otomatik Ekran Yenileme Hızı (Pilde ve Şarjda)";
        }

        private void ButtonUltimate_MouseHover(object? sender, EventArgs e)
        {
            labelTipGPU.Text = "En yüksek performans için sadece dGPU kullanılır";
        }

        private void ButtonStandard_MouseHover(object? sender, EventArgs e)
        {
            labelTipGPU.Text = "Normal kullanım için dGPU ve iGPU kullanılır";
        }

        private void ButtonEco_MouseHover(object? sender, EventArgs e)
        {
            labelTipGPU.Text = "Batarya tasarrufu için sadece iGPU kullanılır";
        }

        private void ButtonOptimized_MouseHover(object? sender, EventArgs e)
        {
            labelTipGPU.Text = "Otomatik GPU modu (Pilde ve Şarjda)";
        }

        private void ButtonGPU_MouseLeave(object? sender, EventArgs e)
        {
            labelTipGPU.Text = "";
        }


        private void ButtonOptimized_Click(object? sender, EventArgs e)
        {
            Program.config.setConfig("gpu_auto", (Program.config.getConfig("gpu_auto") == 1) ? 0 : 1);
            VisualiseGPUMode();
            AutoGPUMode(SystemInformation.PowerStatus.PowerLineStatus);
        }

        private void ButtonScreenAuto_Click(object? sender, EventArgs e)
        {
            Program.config.setConfig("screen_auto", 1);
            InitScreen();
            AutoScreen(SystemInformation.PowerStatus.PowerLineStatus);
        }

        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case NativeMethods.WM_POWERBROADCAST:
                    if (m.WParam == (IntPtr)NativeMethods.PBT_POWERSETTINGCHANGE)
                    {
                        var settings = (NativeMethods.POWERBROADCAST_SETTING)m.GetLParam(typeof(NativeMethods.POWERBROADCAST_SETTING));
                        switch (settings.Data)
                        {
                            case 0:
                                Logger.WriteLine("Monitor Power Off");
                                break;
                            case 1:
                                Logger.WriteLine("Monitor Power On");
                                Program.settingsForm.BeginInvoke(delegate
                                {
                                    Program.SetAutoModes();
                                });
                                break;
                            case 2:
                                Logger.WriteLine("Monitor Dimmed");
                                break;
                        }
                    }
                    m.Result = (IntPtr)1;
                    break;
            }
            base.WndProc(ref m);
        }


        void SetVersionLabel(string label, string url = null)
        {
            labelVersion.Text = label;
            if (url is not null)
            {
                this.versionUrl = url;
                labelVersion.ForeColor = Color.Red;
            }
        }


        private void LabelVersion_Click(object? sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(versionUrl) { UseShellExecute = true });
        }


        private void CheckStartup_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is null) return;
            CheckBox chk = (CheckBox)sender;

            if (chk.Checked)
            {
                Startup.Schedule();
            }
            else
            {
                Startup.UnSchedule();
            }
        }

        private void CheckMatrix_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is null) return;
            CheckBox check = (CheckBox)sender;
            Program.config.setConfig("matrix_auto", check.Checked ? 1 : 0);
        }

        private static void StartMatrixTimer(int interval = 100)
        {
            matrixTimer.Interval = interval;
            matrixTimer.Enabled = true;
        }

        private static void StopMatrixTimer()
        {
            matrixTimer.Enabled = false;
        }

        private static void MatrixTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (mat is null) return;

            switch (Program.config.getConfig("matrix_running"))
            {
                case 2:
                    mat.PresentNextFrame();
                    break;
                case 3:
                    mat.PresentText(DateTime.Now.ToString("H:mm:ss"));
                    break;
            }

        }

        void SetMatrixPicture(string fileName)
        {

            if (mat is null) return;
            StopMatrixTimer();

            Image image;

            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    image = Image.FromStream(ms);
                }
            }
            catch
            {
                Debug.WriteLine("Error loading picture");
                return;
            }

            mat.SetBuiltInAnimation(false);
            mat.ClearFrames();

            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);

            if (frameCount > 1)
            {
                for (int i = 0; i < frameCount; i++)
                {
                    image.SelectActiveFrame(dimension, i);
                    mat.GenerateFrame(image);
                    mat.AddFrame();
                }

                StartMatrixTimer();
            }
            else
            {
                mat.GenerateFrame(image);
                mat.Present();
            }
        }


        private void ButtonMatrix_Click(object? sender, EventArgs e)
        {
            string fileName = null;

            Thread t = new Thread(() =>
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png,*.gif)|*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    fileName = of.FileName;
                }
                return;
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (fileName is not null)
            {
                Program.config.setConfig("matrix_picture", fileName);
                Program.config.setConfig("matrix_running", 2);

                SetMatrixPicture(fileName);
                BeginInvoke(delegate
                {
                    comboMatrixRunning.SelectedIndex = 2;
                });
            }


        }

        private void ComboMatrixRunning_SelectedValueChanged(object? sender, EventArgs e)
        {
            Program.config.setConfig("matrix_running", comboMatrixRunning.SelectedIndex);
            SetMatrix();
        }


        private void ComboMatrix_SelectedValueChanged(object? sender, EventArgs e)
        {
            Program.config.setConfig("matrix_brightness", comboMatrix.SelectedIndex);
            SetMatrix();
        }

        public void SetMatrix(PowerLineStatus Plugged = PowerLineStatus.Online)
        {

            if (mat is null) return;

            int brightness = Program.config.getConfig("matrix_brightness");
            int running = Program.config.getConfig("matrix_running");
            bool auto = Program.config.getConfig("matrix_auto") == 1;

            if (brightness < 0) brightness = 0;
            if (running < 0) running = 0;

            BuiltInAnimation animation = new BuiltInAnimation(
                (BuiltInAnimation.Running)running,
                BuiltInAnimation.Sleeping.Starfield,
                BuiltInAnimation.Shutdown.SeeYa,
                BuiltInAnimation.Startup.StaticEmergence
            );

            StopMatrixTimer();

            mat.SetProvider();

            if (brightness == 0 || (auto && Plugged != PowerLineStatus.Online))
            {
                mat.SetDisplayState(false);
            }
            else
            {
                mat.SetDisplayState(true);
                mat.SetBrightness((BrightnessMode)brightness);

                switch (running)
                {
                    case 2:
                        SetMatrixPicture(Program.config.getConfigString("matrix_picture"));
                        break;
                    case 3:
                        mat.SetBuiltInAnimation(false);
                        StartMatrixTimer(1000);
                        break;
                    default:
                        mat.SetBuiltInAnimation(true, animation);
                        break;

                }

                //mat.SetBrightness((BrightnessMode)brightness);
            }

        }



        private void LabelCPUFan_Click(object? sender, EventArgs e)
        {
            Program.config.setConfig("fan_rpm", (Program.config.getConfig("fan_rpm") == 1) ? 0 : 1);
            RefreshSensors();
        }

        private void PictureColor2_Click(object? sender, EventArgs e)
        {

            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.Color = pictureColor2.BackColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Program.config.setConfig("aura_color2", colorDlg.Color.ToArgb());
                SetAura();
            }
        }

        private void PictureColor_Click(object? sender, EventArgs e)
        {
            buttonKeyboardColor.PerformClick();
        }

        private void ButtonKeyboard_Click(object? sender, EventArgs e)
        {
            if (keyb == null || keyb.Text == "")
            {
                keyb = new Keyboard();
                keyb.Show();
            }
            else
            {
                keyb.Close();
            }
        }

        private void ButtonFans_Click(object? sender, EventArgs e)
        {
            if (fans == null || fans.Text == "")
            {
                fans = new Fans();
                //Debug.WriteLine("Starting fans");
            }

            if (fans.Visible)
            {
                fans.Hide();
            }
            else
            {
                fans.Show();
            }


        }

        private void ButtonKeyboardColor_Click(object? sender, EventArgs e)
        {

            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.Color = pictureColor.BackColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Program.config.setConfig("aura_color", colorDlg.Color.ToArgb());
                SetAura();
            }
        }

        public void InitAura()
        {
            Aura.Mode = Program.config.getConfig("aura_mode");
            Aura.Speed = Program.config.getConfig("aura_speed");
            Aura.SetColor(Program.config.getConfig("aura_color"));
            Aura.SetColor2(Program.config.getConfig("aura_color2"));

            comboKeyboard.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKeyboard.DataSource = new BindingSource(Aura.GetModes(), null);
            comboKeyboard.DisplayMember = "Value";
            comboKeyboard.ValueMember = "Key";
            comboKeyboard.SelectedValue = Aura.Mode;
            comboKeyboard.SelectedValueChanged += ComboKeyboard_SelectedValueChanged;

            comboKeyboardSpeed.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKeyboardSpeed.DataSource = new BindingSource(Aura.GetSpeeds(), null);
            comboKeyboardSpeed.DisplayMember = "Value";
            comboKeyboardSpeed.ValueMember = "Key";
            comboKeyboardSpeed.SelectedValue = Aura.Speed;
            comboKeyboardSpeed.SelectedValueChanged += ComboKeyboardSpeed_SelectedValueChanged;


            pictureColor.BackColor = Aura.Color1;
            pictureColor2.BackColor = Aura.Color2;
            pictureColor2.Visible = Aura.HasSecondColor();
        }

        public void InitMatrix()
        {

            try
            {
                mat = new AnimeMatrixDevice();
                matrixTimer = new System.Timers.Timer(100);
                matrixTimer.Elapsed += MatrixTimer_Elapsed;
            }
            catch
            {
                panelMatrix.Visible = false;
                return;
            }

            int brightness = Program.config.getConfig("matrix_brightness");
            int running = Program.config.getConfig("matrix_running");

            comboMatrix.SelectedIndex = (brightness != -1) ? Math.Min(brightness, comboMatrix.Items.Count - 1) : 0;
            comboMatrixRunning.SelectedIndex = (running != -1) ? Math.Min(running, comboMatrixRunning.Items.Count - 1) : 0;

            checkMatrix.Checked = (Program.config.getConfig("matrix_auto") == 1);


        }


        public void SetAura()
        {
            Aura.Mode = Program.config.getConfig("aura_mode");
            Aura.Speed = Program.config.getConfig("aura_speed");
            Aura.SetColor(Program.config.getConfig("aura_color"));
            Aura.SetColor2(Program.config.getConfig("aura_color2"));

            pictureColor.BackColor = Aura.Color1;
            pictureColor2.BackColor = Aura.Color2;
            pictureColor2.Visible = Aura.HasSecondColor();

            Aura.ApplyAura();

        }

        public void CycleAuraMode()
        {
            if (comboKeyboard.SelectedIndex < comboKeyboard.Items.Count-1) 
                comboKeyboard.SelectedIndex += 1;
            else
                comboKeyboard.SelectedIndex = 0;
        }

        private void ComboKeyboard_SelectedValueChanged(object? sender, EventArgs e)
        {
            Program.config.setConfig("aura_mode", (int)comboKeyboard.SelectedValue);
            SetAura();
        }

        private void ComboKeyboardSpeed_SelectedValueChanged(object? sender, EventArgs e)
        {
            Program.config.setConfig("aura_speed", (int)comboKeyboardSpeed.SelectedValue);
            SetAura();
        }


        private void Button120Hz_Click(object? sender, EventArgs e)
        {
            Program.config.setConfig("screen_auto", 0);
            SetScreen(1000, 1);
        }

        private void Button60Hz_Click(object? sender, EventArgs e)
        {
            Program.config.setConfig("screen_auto", 0);
            SetScreen(60, 0);
        }

        private void ButtonMiniled_Click(object? sender, EventArgs e)
        {
            int miniled = (Program.config.getConfig("miniled") == 1) ? 0 : 1;
            Program.config.setConfig("miniled", miniled);
            SetScreen(-1, -1, miniled);
        }

        public void SetScreen(int frequency = -1, int overdrive = -1, int miniled = -1)
        {

            if (NativeMethods.GetRefreshRate() < 0) // Laptop screen not detected or has unknown refresh rate
            {
                InitScreen();
                return;
            }

            if (frequency >= 1000)
            {
                frequency = Program.config.getConfig("max_frequency");
                if (frequency <= 60) frequency = 120;
            }

            if (frequency > 0)
            {
                NativeMethods.SetRefreshRate(frequency);
                Logger.WriteLine("Screen " + frequency.ToString() + "Hz");
            }

            if (overdrive >= 0)
                Program.wmi.DeviceSet(ASUSWmi.ScreenOverdrive, overdrive);

            if (miniled >= 0)
            {
                Program.wmi.DeviceSet(ASUSWmi.ScreenMiniled, miniled);
                Debug.WriteLine("Miniled " + miniled);
            }

            InitScreen();

        }

        public void InitScreen()
        {

            int frequency = NativeMethods.GetRefreshRate();
            int maxFrequency = Program.config.getConfig("max_frequency");

            bool screenAuto = (Program.config.getConfig("screen_auto") == 1);

            int overdrive = Program.wmi.DeviceGet(ASUSWmi.ScreenOverdrive);
            int miniled = Program.wmi.DeviceGet(ASUSWmi.ScreenMiniled);

            bool screenEnabled = (frequency >= 0);

            ButtonEnabled(button60Hz, screenEnabled);
            ButtonEnabled(button120Hz, screenEnabled);
            ButtonEnabled(buttonScreenAuto, screenEnabled);
            ButtonEnabled(buttonMiniled, screenEnabled);

            labelSreen.Text = screenEnabled
                ? "Laptop Ekranı: " + frequency + "Hz" + ((overdrive == 1) ? " + Overdrive" : "")
                : "Laptop Screen: Turned off";

            button60Hz.Activated = false;
            button120Hz.Activated = false;
            buttonScreenAuto.Activated = false;

            if (screenAuto)
            {
                buttonScreenAuto.Activated = true;
            }
            else if (frequency == 60)
            {
                button60Hz.Activated = true;
            }
            else
            {
                if (frequency > 60)
                    maxFrequency = frequency;

                Program.config.setConfig("max_frequency", maxFrequency);
                button120Hz.Activated = true;
            }

            if (maxFrequency > 60)
            {
                button120Hz.Text = maxFrequency.ToString() + "Hz + OD";
            }

            if (miniled >= 0)
            {
                buttonMiniled.Activated = (miniled == 1);
                Program.config.setConfig("miniled", miniled);
            }
            else
            {
                buttonMiniled.Visible = false;
            }

            Program.config.setConfig("frequency", frequency);
            Program.config.setConfig("overdrive", overdrive);
        }

        private void ButtonQuit_Click(object? sender, EventArgs e)
        {
            Close();
            Program.trayIcon.Visible = false;
            Application.Exit();
        }

        private void SettingsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ButtonUltimate_Click(object? sender, EventArgs e)
        {
            SetGPUMode(ASUSWmi.GPUModeUltimate);
        }

        private void ButtonStandard_Click(object? sender, EventArgs e)
        {
            SetGPUMode(ASUSWmi.GPUModeStandard);
        }

        private void ButtonEco_Click(object? sender, EventArgs e)
        {
            SetGPUMode(ASUSWmi.GPUModeEco);
        }


        private static string FormatFan(int fan)
        {
            if (fan < 0) return null;

            if (Program.config.getConfig("fan_rpm") == 1)
                return " Fan: " + (fan * 100).ToString() + "RPM";
            else
                return " Fan: " + Math.Min(Math.Round(fan / 0.6), 100).ToString() + "%"; // relatively to 6000 rpm
        }

        private static void RefreshSensors()
        {

            if (Math.Abs(DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastRefresh) < 2000) return;
            lastRefresh = DateTimeOffset.Now.ToUnixTimeMilliseconds();

            string cpuFan = FormatFan(Program.wmi.DeviceGet(ASUSWmi.CPU_Fan));
            string gpuFan = FormatFan(Program.wmi.DeviceGet(ASUSWmi.GPU_Fan));
            string midFan = FormatFan(Program.wmi.DeviceGet(ASUSWmi.Mid_Fan));

            string cpuTemp = "";
            string gpuTemp = "";
            string battery = "";

            HardwareMonitor.ReadSensors();

            if (HardwareMonitor.cpuTemp > 0)
                cpuTemp = ": " + Math.Round((decimal)HardwareMonitor.cpuTemp).ToString() + "°C - ";

            if (HardwareMonitor.batteryDischarge > 0)
                battery = "Discharging: " + Math.Round((decimal)HardwareMonitor.batteryDischarge, 1).ToString() + "W";

            if (HardwareMonitor.gpuTemp != null)
            {
                gpuTemp = $": {HardwareMonitor.gpuTemp}°C - ";
            }

            Program.settingsForm.BeginInvoke(delegate
            {
                Program.settingsForm.labelCPUFan.Text = "CPU" + cpuTemp + cpuFan;
                Program.settingsForm.labelGPUFan.Text = "GPU" + gpuTemp + gpuFan;
                if (midFan is not null) Program.settingsForm.labelMidFan.Text = "Mid" + midFan;
                Program.settingsForm.labelBattery.Text = battery;

                Program.trayIcon.Text = "CPU" + cpuTemp + cpuFan + "\n" + "GPU" + gpuTemp + gpuFan + ((battery.Length > 0) ? ("\n" + battery) : "");

            });
        }


        private void SettingsForm_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                InitScreen();

                this.Left = Screen.FromControl(this).WorkingArea.Width - 10 - this.Width;
                this.Top = Screen.FromControl(this).WorkingArea.Height - 10 - this.Height;
                this.Activate();

                aTimer.Interval = 300;
                aTimer.Enabled = true;

                //RefreshSensors();
            }
            else
            {
                aTimer.Enabled = false;
            }
        }

        public void SetPower()
        {
            int limit_total = Program.config.getConfigPerf("limit_total");
            int limit_cpu = Program.config.getConfigPerf("limit_cpu");

            if (limit_total > ASUSWmi.MaxTotal) return;
            if (limit_total < ASUSWmi.MinTotal) return;

            if (limit_cpu > ASUSWmi.MaxCPU) return;
            if (limit_cpu < ASUSWmi.MinCPU) return;

            if (Program.wmi.DeviceGet(ASUSWmi.PPT_TotalA0) >= 0)
                Program.wmi.DeviceSet(ASUSWmi.PPT_TotalA0, limit_total);

            if (Program.wmi.DeviceGet(ASUSWmi.PPT_CPUB0) >= 0)
                Program.wmi.DeviceSet(ASUSWmi.PPT_CPUB0, limit_cpu);

            Logger.WriteLine("PowerLimits " + limit_total.ToString() + ", " + limit_cpu.ToString());


        }


        public void AutoFansAndPower()
        {

            if (Program.config.getConfigPerf("auto_apply") == 1)
            {
                Program.wmi.SetFanCurve(0, Program.config.getFanConfig(0));
                Program.wmi.SetFanCurve(1, Program.config.getFanConfig(1));

                if (Program.config.getConfig("mid_fan") == 1)
                    Program.wmi.SetFanCurve(2, Program.config.getFanConfig(2));
            }

            if (Program.config.getConfigPerf("auto_apply_power") == 1)
            {
                var timer = new System.Timers.Timer(1000);
                timer.Elapsed += delegate
                {
                    timer.Stop();
                    timer.Dispose();
                    SetPower();
                };
                timer.Start();
            }

        }

        public void SetPerformanceMode(int PerformanceMode = ASUSWmi.PerformanceBalanced, bool notify = false)
        {


            buttonSilent.Activated = false;
            buttonBalanced.Activated = false;
            buttonTurbo.Activated = false;

            switch (PerformanceMode)
            {
                case ASUSWmi.PerformanceSilent:
                    buttonSilent.Activated = true;
                    perfName = "Silent";
                    break;
                case ASUSWmi.PerformanceTurbo:
                    buttonTurbo.Activated = true;
                    perfName = "Turbo";
                    break;
                default:
                    buttonBalanced.Activated = true;
                    PerformanceMode = ASUSWmi.PerformanceBalanced;
                    perfName = "Balanced";
                    break;
            }

            int oldMode = Program.config.getConfig("performance_mode");
            Program.config.setConfig("performance_" + (int)SystemInformation.PowerStatus.PowerLineStatus, PerformanceMode);
            Program.config.setConfig("performance_mode", PerformanceMode);

            Program.wmi.DeviceSet(ASUSWmi.PerformanceMode, PerformanceMode);
            Logger.WriteLine("PerfMode " + perfName + " " + PerformanceMode);

            if (notify && (oldMode != PerformanceMode))
            {
                try
                {
                    Program.toast.RunToast(perfName);
                }
                catch
                {
                    Debug.WriteLine("Toast error");
                }
            }

            AutoFansAndPower();

            NativeMethods.SetPowerScheme(PerformanceMode);

            if (NativeMethods.PowerGetEffectiveOverlayScheme(out Guid activeScheme) == 0)
            {
                Debug.WriteLine("Effective :" + activeScheme);
            }

            if (fans != null && fans.Text != "")
            {
                fans.InitFans();
                fans.InitPower();
            }



        }


        public void CyclePerformanceMode()
        {
            SetPerformanceMode(Program.config.getConfig("performance_mode") + 1, true);
        }

        public void AutoPerformance(PowerLineStatus Plugged = PowerLineStatus.Online)
        {
            int mode = Program.config.getConfig("performance_" + (int)Plugged);
            if (mode != -1)
                SetPerformanceMode(mode, true);
            else
                SetPerformanceMode(Program.config.getConfig("performance_mode"));
        }


        public void AutoScreen(PowerLineStatus Plugged = PowerLineStatus.Online)
        {
            if (Program.config.getConfig("screen_auto") != 1) return;

            if (Plugged == PowerLineStatus.Online)
                SetScreen(1000, 1);
            else
                SetScreen(60, 0);


        }

        public bool AutoGPUMode(PowerLineStatus Plugged = PowerLineStatus.Online)
        {

            bool GpuAuto = Program.config.getConfig("gpu_auto") == 1;
            if (!GpuAuto) return false;

            int eco = Program.wmi.DeviceGet(ASUSWmi.GPUEco);
            int mux = Program.wmi.DeviceGet(ASUSWmi.GPUMux);

            if (mux == 0) // GPU in Ultimate, ignore
                return false;
            else
            {
                if (eco == 1 && Plugged == PowerLineStatus.Online)  // Eco going Standard on plugged
                {
                    SetEcoGPU(0);
                    return true;
                }
                else if (eco == 0 && Plugged != PowerLineStatus.Online)  // Standard going Eco on plugged
                {
                    SetEcoGPU(1);
                    return true;
                }
            }

            return false;

        }

        private void UltimateUI(bool ultimate)
        {
            if (!ultimate)
            {
                tableGPU.Controls.Remove(buttonUltimate);
                tablePerf.ColumnCount = 0;
                tableGPU.ColumnCount = 0;
                tableScreen.ColumnCount = 0;

            }

            //tableLayoutMatrix.ColumnCount = 0;


        }

        public int InitGPUMode()
        {

            int eco = Program.wmi.DeviceGet(ASUSWmi.GPUEco);
            int mux = Program.wmi.DeviceGet(ASUSWmi.GPUMux);

            int GpuMode;

            if (mux == 0)
                GpuMode = ASUSWmi.GPUModeUltimate;
            else
            {
                if (eco == 1)
                    GpuMode = ASUSWmi.GPUModeEco;
                else
                    GpuMode = ASUSWmi.GPUModeStandard;

                UltimateUI(mux == 1);

            }

            Program.config.setConfig("gpu_mode", GpuMode);

            ButtonEnabled(buttonOptimized, true);
            ButtonEnabled(buttonEco, true);
            ButtonEnabled(buttonStandard, true);
            ButtonEnabled(buttonUltimate, true);

            VisualiseGPUMode(GpuMode);

            return GpuMode;

        }


        public void SetEcoGPU(int eco)
        {

            ButtonEnabled(buttonOptimized, false);
            ButtonEnabled(buttonEco, false);
            ButtonEnabled(buttonStandard, false);
            ButtonEnabled(buttonUltimate, false);

            labelGPU.Text = "GPU Modu: Değiştiriliyor ...";

            Thread t = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (eco == 1)
                {
                    string[] tokill = { "EADesktop", "RadeonSoftware" };
                    foreach (string kill in tokill)
                        foreach (var process in Process.GetProcessesByName(kill)) process.Kill();
                }

                Program.wmi.DeviceSet(ASUSWmi.GPUEco, eco);
                Program.settingsForm.BeginInvoke(delegate
                {
                    InitGPUMode();
                    HardwareMonitor.RecreateGpuTemperatureProviderWithDelay();
                    Thread.Sleep(500);
                    AutoScreen(SystemInformation.PowerStatus.PowerLineStatus);
                });
            });

            t.Start();

        }

        public void SetGPUMode(int GPUMode)
        {

            int CurrentGPU = Program.config.getConfig("gpu_mode");
            Program.config.setConfig("gpu_auto", 0);

            if (CurrentGPU == GPUMode)
            {
                VisualiseGPUMode();
                return;
            }

            var restart = false;
            var changed = false;

            if (CurrentGPU == ASUSWmi.GPUModeUltimate)
            {
                DialogResult dialogResult = MessageBox.Show("Ultimate Mod'u kapatmak yeniden başlatma gerektirir", "Şimdi yeniden başlat?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Program.wmi.DeviceSet(ASUSWmi.GPUMux, 1);
                    restart = true;
                    changed = true;
                }
            }
            else if (GPUMode == ASUSWmi.GPUModeUltimate)
            {
                DialogResult dialogResult = MessageBox.Show("Ultimate Mod'u açmak yeniden başlatma gerektiriyor", "Şimdi yeniden başlat?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Program.wmi.DeviceSet(ASUSWmi.GPUMux, 0);
                    restart = true;
                    changed = true;
                }

            }
            else if (GPUMode == ASUSWmi.GPUModeEco)
            {
                VisualiseGPUMode(GPUMode);
                SetEcoGPU(1);
                changed = true;
            }
            else if (GPUMode == ASUSWmi.GPUModeStandard)
            {
                VisualiseGPUMode(GPUMode);
                SetEcoGPU(0);
                changed = true;
            }

            if (changed)
            {
                Program.config.setConfig("gpu_mode", GPUMode);
            }

            if (restart)
            {
                VisualiseGPUMode();
                Process.Start("shutdown", "/r /t 1");
            }

        }


        public void VisualiseGPUMode(int GPUMode = -1)
        {

            if (GPUMode == -1)
                GPUMode = Program.config.getConfig("gpu_mode");

            bool GPUAuto = (Program.config.getConfig("gpu_auto") == 1);

            buttonEco.Activated = false;
            buttonStandard.Activated = false;
            buttonUltimate.Activated = false;
            buttonOptimized.Activated = false;

            switch (GPUMode)
            {
                case ASUSWmi.GPUModeEco:
                    buttonOptimized.BorderColor = colorEco;
                    buttonEco.Activated = !GPUAuto;
                    buttonOptimized.Activated = GPUAuto;
                    labelGPU.Text = "GPU Modu: Sadece iGPU";
                    Program.trayIcon.Icon = Properties.Resources.eco;
                    break;
                case ASUSWmi.GPUModeUltimate:
                    buttonUltimate.Activated = true;
                    labelGPU.Text = "GPU Modu: Sadece dGPU";
                    Program.trayIcon.Icon = Properties.Resources.ultimate;
                    break;
                default:
                    buttonOptimized.BorderColor = colorStandard;
                    buttonStandard.Activated = !GPUAuto;
                    buttonOptimized.Activated = GPUAuto;
                    labelGPU.Text = "GPU Modu: iGPU + dGPU";
                    Program.trayIcon.Icon = Properties.Resources.standard;
                    break;
            }


        }


        private void ButtonSilent_Click(object? sender, EventArgs e)
        {
            SetPerformanceMode(ASUSWmi.PerformanceSilent);
        }

        private void ButtonBalanced_Click(object? sender, EventArgs e)
        {
            SetPerformanceMode(ASUSWmi.PerformanceBalanced);
        }

        private void ButtonTurbo_Click(object? sender, EventArgs e)
        {
            SetPerformanceMode(ASUSWmi.PerformanceTurbo);
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        public void ButtonEnabled(RButton but, bool enabled)
        {
            but.Enabled = enabled;
            but.BackColor = but.Enabled ? Color.FromArgb(255, but.BackColor) : Color.FromArgb(100, but.BackColor);
        }

        public void SetStartupCheck(bool status)
        {
            checkStartup.CheckedChanged -= CheckStartup_CheckedChanged;
            checkStartup.Checked = status;
            checkStartup.CheckedChanged += CheckStartup_CheckedChanged;
        }

        public void SetBatteryChargeLimit(int limit)
        {

            if (limit < 40 || limit > 100) return;

            labelBatteryTitle.Text = "Pil Şarj Sınırı: " + limit.ToString() + "%";
            trackBattery.Value = limit;

            Program.wmi.DeviceSet(ASUSWmi.BatteryLimit, limit);
            Program.config.setConfig("charge_limit", limit);

        }


    }


}
