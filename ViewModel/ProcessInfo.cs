using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;

namespace WpfAppTaskbarManager.ViewModel
{
    public class ProcessInfo : INotifyPropertyChanged
    {
        private int _Memory;
        private float _CPU;
        private float _Disk;
        private float _GPU;

        private string _ProcessID = "";
        private string _NameProcess = "";
        private string _Status = "";

        public string StatusProcess
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged(nameof(StatusProcess));
            }
        }

        public string NameProcess
        {
            get { return _NameProcess; }
            set
            {
                _NameProcess = value;
                OnPropertyChanged(nameof(NameProcess));
            }
        }

        public string IDProcess
        {
            get { return _ProcessID; }
            set
            {
                _ProcessID = value;
                OnPropertyChanged(nameof(IDProcess));
            }
        }

        public float GPUUsage
        {
            get { return _GPU; }
            set
            {
                _GPU = value;
                OnPropertyChanged(nameof(GPUUsage));
            }
        }

        public int MemoryUsage
        {
            get { return _Memory; }
            set
            {
                _Memory = value;
                OnPropertyChanged(nameof(MemoryUsage));
            }
        }

        public float CPUUsage
        {
            get { return _CPU; }
            set
            {
                _CPU = value;
                OnPropertyChanged(nameof(CPUUsage));
            }
        }

        public float DiskUsage
        {
            get { return _Disk; }
            set
            {
                _Disk = value;
                OnPropertyChanged(nameof(DiskUsage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProcessInfoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProcessInfo> _processes = new ObservableCollection<ProcessInfo>();

        public ObservableCollection<ProcessInfo> Processes
        {
            get { return _processes; }
        }

        public ProcessInfoViewModel()
        {
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            _processes.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    ProcessInfo processInfo = GetProcessInfo(process);
                    _processes.Add(processInfo);
                }
                catch (Exception ex)
                {
                    // Ghi nhận lỗi hoặc hiển thị thông báo lỗi
                    Console.WriteLine($"Error loading process: {ex.Message}");
                    // Tiếp tục với các tiến trình khác
                    continue;
                }
            }
        }

        private static ProcessInfo GetProcessInfo(Process process)
        {
            PerformanceCounter cpuCounter;
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            return new ProcessInfo
            {
                NameProcess = process.ProcessName,
                IDProcess = process.Id.ToString(), // Convert to string
                StatusProcess = process.MainModule?.FileName ?? "Unknown", // Lấy đường dẫn của module chính (thường là file exe)
                MemoryUsage = (int)(process.WorkingSet64 / 1024), // Đơn vị là KB
                CPUUsage = (float)(cpuCounter.NextValue()), // Thời gian CPU đã sử dụng tính theo % của mỗi core
                DiskUsage = 0,
                GPUUsage = 0
            };
        }

        // Move this method outside of LoadProcesses
        public object getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            return secondValue;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
