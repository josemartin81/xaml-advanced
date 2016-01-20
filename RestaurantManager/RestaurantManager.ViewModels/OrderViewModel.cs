using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private ObservableCollection<MenuItem> _currentlySelectedMenuItems = null;

        private ObservableCollection<MenuItem> _menuItems = null;

        private MenuItem _selectedMenuItem;
        private string _specialRequests;

        public OrderViewModel()
        {
            AddMenuItemCommand = new DelegateCommand(AddMenuItem);
            SubmitOrderCommand = new DelegateCommand(SubmitOrder);
        }

        public ICommand AddMenuItemCommand { get; private set; }

        public ICommand SubmitOrderCommand { get; private set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get
            {
                return _currentlySelectedMenuItems ?? (_currentlySelectedMenuItems = new ObservableCollection<MenuItem>());
            }

            set
            {
                if (value != null)
                {
                    _currentlySelectedMenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get
            {
                return _menuItems ?? (_menuItems = new ObservableCollection<MenuItem>());
            }

            set
            {
                if (value != null)
                {
                    _menuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public MenuItem SelectedMenuItem
        {
            get
            {
                return _selectedMenuItem;
            }

            set
            {
                if (value != null)
                {
                    _selectedMenuItem = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string SpecialRequests
        {
            get
            {
                return _specialRequests;
            }

            set
            {
                if (value != null)
                {
                    _specialRequests = value;
                    this.OnPropertyChanged();
                }
            }
        }

        protected override void OnDataLoaded()
        {
            base.Repository.StandardMenuItems.ForEach(p => this.MenuItems.Add(p));
        }

        private void AddMenuItem()
        {
            this.CurrentlySelectedMenuItems.Add(SelectedMenuItem);
        }

        private void SubmitOrder()
        {
            base.Repository.Orders.Add(new Order
            {
                Complete = false,
                Expedite = true,
                SpecialRequests = SpecialRequests,
                Table = base.Repository.Tables.Last(),
                Items = this.CurrentlySelectedMenuItems.ToList()
            });

            this.SelectedMenuItem = null;
            this.SpecialRequests = string.Empty;
            this.CurrentlySelectedMenuItems.Clear();
        }
    }
}