using System;
using System.Reflection;
using Xamarin.Forms;

namespace Labb4Countries
{
    public static class CountryExtension
    {
        
            public static ImageSource GetImageSource(this Country country)
            {

                return ImageSource.FromResource(country.ImageUrl, country.GetType().GetTypeInfo().Assembly);
            }
        
    }
    }

