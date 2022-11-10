﻿using AgendaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;//<-- Agregué esto
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command; // ... esto
using System.Windows.Input;

namespace AgendaMVVM.ViewModels
{
    public class AgendaViewModel:INotifyPropertyChanged // <<- y esto
    {

        public AgendaViewModel()
        {
            Cargar();
            VerCommand=new RelayCommand(Ver);
        }

        private ObservableCollection<Contacto> contactos;

        void RaiseEvent(string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Ver()
        {
            if (Contacto!=null)
            {
                CambiarVista("Detalle");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged; // <- también esto
        public ICommand VerCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ObservableCollection<Contacto> Contactos
        {
            get { return contactos; }
            set { contactos = value; }
        }

        public void Cargar()
        {
            contactos = new ObservableCollection<Contacto>();
            contactos.Add(new()
            {
                Nombre="Hugo",
                Id=0,
                Correo="hugo@pato.org"
            });
            contactos.Add(new()
            {
                Nombre = "Paco",
                Id = 1,
                Correo = "paco@pato.org"
            });
            contactos.Add(new()
            {
                Nombre = "Luis",
                Id = 2,
                Correo = "luis@pato.org"
            });
        }

        public Contacto Contacto { get; set; }

        public string Vista { get; set; }="";
        private void CambiarVista(string vista)
        {
            Vista = vista;
            RaiseEvent();        }
    }
}
