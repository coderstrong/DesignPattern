using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IDevice dv = new Radio();
            Remote rm = new SimpleRemote(dv);
            rm.togglePower();

            dv = new Television();
            rm = new SimpleRemote(dv);
            rm.togglePower();
        }
    }

    #region Bridge
    public interface IDevice
    {
        bool isEnabled();
        void enable();
        void disable();
        int getVolume();
        void setVolume(int percent);
    }

    public abstract class Remote
    {
        protected IDevice device { get; set; }

        public Remote(IDevice device)
        {
            this.device = device;
        }

        public void togglePower()
        {
            if (device.isEnabled())
            {
                device.disable();
            }
            else
            {
                device.enable();
            }
        }

        public void volumeDown()
        {
            int old = device.getVolume();
            device.setVolume(old - 1);
        }
    }

    #endregion

    public class Television : IDevice
    {
        private bool currentstate = false;
        private int currentvolume = 50;
        public void disable()
        {
            Console.WriteLine("Television off");
            this.currentstate = false;
        }

        public void enable()
        {
            Console.WriteLine("Television on");
            this.currentstate = true;
        }

        public bool isEnabled()
        {
            return this.currentstate;
        }

        public int getVolume()
        {
            return this.currentvolume;
        }

        public void setVolume(int percent)
        {
            this.currentvolume = percent;
        }
    }

    public class Radio : IDevice
    {
        private bool currentstate = false;
        private int currentvolume = 50;
        public void disable()
        {
            Console.WriteLine("Radio off");
            this.currentstate = false;
        }

        public void enable()
        {
            Console.WriteLine("Radio on");
            this.currentstate = true;
        }

        public bool isEnabled()
        {
            return this.currentstate;
        }

        public int getVolume()
        {
            return this.currentvolume;
        }

        public void setVolume(int percent)
        {
            this.currentvolume = percent;
        }
    }

    public class SimpleRemote : Remote
    {
        public SimpleRemote(IDevice device) : base(device)
        {
        }
    }
    public class AdvancedRemoted : Remote
    {
        public AdvancedRemoted(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            this.device.setVolume(0);
        }
    }
}