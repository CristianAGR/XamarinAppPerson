using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPerson
{
    public partial class MainPage : ContentPage
    {
        public List<PersonModel> Persons;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonLoadPersons_Clicked(object sender, EventArgs e)
        {
            IndicatorPersons.IsRunning = true;
            ButtonLoadPersons.IsEnabled = false;

            Persons = new List<PersonModel>
            {
                new PersonModel
                {
                    Id = 1,
                    FirstName = "Cristiano",
                    LastName = "Ronaldo",
                    Age = 37,
                    Phone = "3729302781",
                    Picture = "https://www.realmadrid.com/img/vertical_380px/cristiano_550x650_20180917025046.jpg"
                },
                new PersonModel
                {
                    Id = 2,
                    FirstName = "Leo",
                    LastName = "Messi",
                    Age = 35,
                    Phone = "3729302781",
                    Picture = "https://upload.wikimedia.org/wikipedia/commons/b/b8/Messi_vs_Nigeria_2018.jpg"
                },
                new PersonModel
                {
                    Id = 3,
                    FirstName = "Javier",
                    LastName = "Hernández",
                    Age = 35,
                    Phone = "3729302781",
                    Picture = "https://cdn.forbes.com.mx/2020/01/chicharito-640x360.jpg"
                }
            };

            ListPersons.ItemsSource = Persons;

            IndicatorPersons.IsRunning = false;
            ButtonLoadPersons.IsEnabled = true;
        }
        private void ButtonNewPerson_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailView(this));
        }


        public void ListRefresh()
        {
            ListPersons.ItemsSource = null;
            ListPersons.ItemsSource = Persons;

        }

        private void ListPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonModel personSelected = e.CurrentSelection.FirstOrDefault() as PersonModel;
                if( personSelected != null)
            {
                Navigation.PushAsync(new DetailView(this, personSelected));
            }
        }
    }
}
