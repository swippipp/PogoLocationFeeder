﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MangaChecker.ViewModels;

namespace PogoLocationFeeder.GUI.Models {
    public class SniperInfoModel {
        private SniperInfo _info;
        public BitmapImage Icon { get; set; }
        public string Server { get; set; }
        public string Channel { get; set; }

        public SniperInfo Info {
            get { return _info; }
            set {
                _info = value;
                Date = Info.ExpirationTimestamp.Equals(default(DateTime)) ? "Unknown" : Info.ExpirationTimestamp.ToString();
                IV = Info.IV.Equals(0) ? "??" : Info.IV.ToString();
            }
        }

        public string Date { get; set; }

        public string IV { get; set; }

        public SniperInfoModel() {
            copyCoordsCommand = new ActionCommand(CopyCoords);
            PokeSnipersCommand = new ActionCommand(PokeSnipers);
        }

        public void CopyCoords() {
            Clipboard.SetText($"{Info.Latitude}, {Info.Longitude}");
        }
        public void PokeSnipers() {
            Clipboard.SetText($"pokesniper2://{Info.Id}/{Info.Latitude.ToString().Replace(",", ".")},{Info.Longitude.ToString().Replace(",", ".")}");
        }

        public ICommand copyCoordsCommand { get; }
        public ICommand PokeSnipersCommand { get; }
    }
}