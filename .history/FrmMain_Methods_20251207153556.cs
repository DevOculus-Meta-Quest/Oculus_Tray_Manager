
        public void AddToListboxAndScroll(string msg)
        {
            if (this.ListBox1.InvokeRequired)
            {
                this.Invoke(new Action<string>(AddToListboxAndScroll), msg);
            }
            else
            {
                this.ListBox1.Items.Add(msg);
                this.ListBox1.TopIndex = this.ListBox1.Items.Count - 1;
            }
        }

        public void LoadVoiceSettings()
        {
            // Stub implementation
            if (Globals.dbg) Log.WriteToLog("LoadVoiceSettings called");
        }

        public string GetCurrentResolution()
        {
            // Stub implementation
            return "1920x1080"; 
        }

        public void ShowForm()
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }

        // Ensuring ListBox1 exists if not already defined (it is referenced in code so likely missing definition)
        public System.Windows.Forms.ListBox ListBox1; // Adding field if missing

