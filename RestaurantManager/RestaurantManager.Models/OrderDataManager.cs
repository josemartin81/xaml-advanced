using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {

        private List<MenuItem> _MenuItems;
        private List<MenuItem> _CurrentlySelectedMenuItem;


        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        public List<MenuItem> MenuItems {
            get { return this._MenuItems; }
            set
            {
                if (value != this._MenuItems )
                {
                    this._MenuItems = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems {
            get { return this._CurrentlySelectedMenuItem; }
            set
            {
                if (value != this._CurrentlySelectedMenuItem)
                {
                    this._CurrentlySelectedMenuItem = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }
}
