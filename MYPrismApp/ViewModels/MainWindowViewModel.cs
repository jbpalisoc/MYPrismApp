using Microsoft.EntityFrameworkCore;
using MYPrismApp.Model;
using MYPrismApp.Repository;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;


namespace MYPrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //public IAnimalRepository animalrepo { get; set; }
        private readonly MyDbContext _context;
        Animal NewAnimal = new Animal();


         private UnitOfWork unitOfWork = new UnitOfWork(new MyDbContext());

        private string _title = "Animals";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private string _showText;
        public string ShowText
        {
            get { return _showText; }
            set { SetProperty(ref _showText, value); }
        }

        private ObservableCollection<Animal> _animallist;
        public ObservableCollection<Animal> AnimalList
        {
            get { return _animallist; }
            set { SetProperty(ref _animallist, value); }
        }

        private List<TodoItem> _todoList;
        public List<TodoItem> TodoList
        {
            get { return _todoList; }
            set { SetProperty(ref _todoList, value); }
        }

        private Animal _selectedAnimal;
        public Animal SelectedAnimal
        {
            get { return _selectedAnimal; }
            set { SetProperty(ref _selectedAnimal, value);}
        }

        public ICommand SaveAnimal { get; private set; }
        public ICommand DeleteAnimal { get; private set; }
        public ICommand UpdateAnimal { get; private set; }
        public ICommand GetSelected { get; private set; }

        public MainWindowViewModel(MyDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _context.Animals.Load();
            GetAnimals();
            SaveAnimal = new DelegateCommand(Execute);
            DeleteAnimal = new DelegateCommand(ExcuteDelete);
            UpdateAnimal = new DelegateCommand(ExcuteUpdate);
            GetSelected = new DelegateCommand(ExcuteGetSelected);
            Todo();
        }

        private void Execute()
        {
            NewAnimal = new Animal();
            NewAnimal.Name = _name;
            NewAnimal.Description = _description;
            unitOfWork.Animals.Add(NewAnimal);
            unitOfWork.Complete();
            //_context.Animals.Add(NewAnimal);
            //_context.SaveChanges();
            GetAnimals();
            Name = string.Empty;
            Description = string.Empty;
            ShowText = "Item Added!";
        }

        private void ExcuteDelete()
        {     
            _context.Animals.Remove(_selectedAnimal);
            _context.SaveChanges();
            //GetAnimals();
            ShowText = "Item Deleted!";
        }
        private void ExcuteGetSelected()
        {
            Name = _selectedAnimal.Name;
            Description = _selectedAnimal.Description;
        }

        private void ExcuteUpdate()
        {
            NewAnimal = _selectedAnimal;
            NewAnimal.Name = _name;
            NewAnimal.Description = _description;
            _context.Animals.Update(NewAnimal);
            _context.SaveChanges();
            //GetAnimals();
            Name = string.Empty;
            Description = string.Empty;
            CollectionViewSource.GetDefaultView(_animallist).Refresh();
            ShowText = "Item Updated!";
        }

        private void GetAnimals()
        {
            //_animallist = _context.Animals.Local.ToObservableCollection();
            _animallist = new ObservableCollection<Animal>(unitOfWork.Animals.GetAll());
        }

        private void Todo()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44378/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/TodoItems").Result;
            if (response.IsSuccessStatusCode)
            {
                //var employees = response.Content.ReadAsAsync<IEnumerable<List>>().Result;
                _todoList = (List<TodoItem>)response.Content.ReadAsAsync<IEnumerable<TodoItem>>().Result;

            }
        }

    }
}
