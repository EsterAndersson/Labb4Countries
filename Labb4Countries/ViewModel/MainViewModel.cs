using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Labb4Countries
{
    public class MainViewModel : SimpleViewModel
    {

        private CountryRepository countryRepository = new CountryRepository();
        private List<Country> Countries { get; set; }
        
        private Country pickedCountry;
        private int CountryIndex;

        public Command NextButtonCommand { get; set; }
        public Command PreviousButtonCommand { get; set; }


        public MainViewModel()
            {
               
                Countries = countryRepository.GetCountries();
                CurrentCountry = Countries[0];
                NextButtonClicked();
                PreviousButtonClicked();
       }

        

        public Country CurrentCountry
        {
            get
            {
                return pickedCountry;
            }
            set
            {
                SetPropertyValue(ref pickedCountry, value);
                RaiseAllPropertiesChanged();
            }
        }

      

        private void NextButtonClicked()
            {
                NextButtonCommand = new Command(() =>
                {
                    CountryIndex++;
                    if (CountryIndex > Countries.Count() - 1)
                    {
                        CountryIndex = 0;
                    }
                    CurrentCountry = Countries[CountryIndex];
                });
            }

            private void PreviousButtonClicked()
            {
            PreviousButtonCommand = new Command(() =>
                {
                    CountryIndex--;
                    if (CountryIndex < 0)
                    {
                        CountryIndex = Countries.Count() - 1;
                    }
                    CurrentCountry = Countries[CountryIndex];
                });
            }

            

      
    }
    }


