﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class StadionViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;
        private AddStadionViewModel addStadionViewModel = new AddStadionViewModel();
        private ShowStadionViewModel showStadionViewModel = new ShowStadionViewModel();
        private UpdateStadionViewModel updateStadionViewModel = new UpdateStadionViewModel();
        private Visibility visibility;

        public StadionViewModel()
        {
            string role = (string)Application.Current.Properties["Role"];
            if (role != "Admin")
            {
                Visibility = Visibility.Hidden;
            }
            else
            {
                Visibility = Visibility.Visible;
            }
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = showStadionViewModel;
        }

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;

                OnPropertyChanged("Visibility");
            }
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {

                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "myAdd":
                    CurrentViewModel = addStadionViewModel;
                    break;
                case "myShow":
                    CurrentViewModel = showStadionViewModel;
                    break;
                case "myUpdate":
                    CurrentViewModel = updateStadionViewModel;
                    break;

            }
        }
    }
}
