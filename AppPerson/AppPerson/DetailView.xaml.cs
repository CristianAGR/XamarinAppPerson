using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPerson
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        MainPage Mainpage;
        PersonModel  Person = new PersonModel();

        public DetailView(MainPage mainPage)
        {
            InitializeComponent();

            this.Mainpage = mainPage;
        }

        public DetailView(MainPage mainPage, PersonModel person)
        {
            InitializeComponent();

            this.Mainpage = mainPage;

            // Cargar persona seleccionada
            this.Person.Id = person.Id;

            ImagePicture.Source = person.Picture;
            EntryFirstName.Text = person.FirstName;
            EntryLastName.Text = person.LastName;
            EntryAge.Text = person.Age.ToString();
            EntryPhone.Text = person.Phone;
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if (this.Person.Id > 0)
            {
                // Actualizar

                for(int index = 0; index < this.Mainpage.Persons.Count; index++)
                {
                    if(this.Mainpage.Persons[index].Id == this.Person.Id)
                    {
                        this.Mainpage.Persons[index].FirstName = EntryFirstName.Text;
                        this.Mainpage.Persons[index].LastName = EntryLastName.Text;
                        this.Mainpage.Persons[index].Age = int.Parse(EntryAge.Text);
                        this.Mainpage.Persons[index].Phone = EntryPhone.Text;
                        this.Mainpage.Persons[index].Picture = EntryPicture.Text;
                        break;
                    }
                }
            } else
            {
                // Crear
                Person.FirstName = EntryFirstName.Text;
                Person.LastName = EntryLastName.Text;
                Person.Age = int.Parse(EntryAge.Text);
                Person.Phone = EntryPhone.Text;
                Person.Picture = EntryPicture.Text;

                // Agregamos una nueva persona a nuestro listado de personas
                this.Mainpage.Persons.Add(Person);

            }
            // Refrescamos nuestro collecctionview
            this.Mainpage.ListRefresh();

            Navigation.PopAsync();
        }

        private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            if (this.Person.Id > 0)
            {
                // Eliminar
                for (int index = 0; index < this.Mainpage.Persons.Count; index++)
                {
                    if (this.Mainpage.Persons[index].Id == this.Person.Id)
                    {
                        //Opcion1
                        //this.Mainpage.Persons.Remove(this.Mainpage.Persons[index]);
                        //opcion2
                        this.Mainpage.Persons.RemoveAt(index);
                        break;
                    }
                }
            }
            this.Mainpage.ListRefresh();
            Navigation.PopAsync();
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}