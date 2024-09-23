using MigrationForm.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationForm
{

    public class Passengers
    {
        public List<Room> Rooms { get; set; }

        public int GetRoomCount()
        {
            return Rooms?.Count ?? 0;
        }

        public int GetPax()
        {
            int _pax = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    _pax += (room.Adult?.Count ?? 0) + (room.Child?.Count ?? 0);
                }
            }
            return _pax;
        }

        public int GetTotalAdultCount()
        {
            int _adultCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    _adultCount += room.Adult?.Count ?? 0;
                }
            }
            return _adultCount;
        }

        public int GetTotalChildCount()
        {
            int _childCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    _childCount += room.Child?.Count ?? 0;
                }
            }
            return _childCount;
        }

        public int GetTotalChildCountWithoutInfant()
        {
            int _childCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    foreach (Person person in room.Child)
                    {
                        _childCount += (person.Age >= 2 ? 1 : 0);
                    }
                }
            }
            return _childCount;
        }

        public int GetTotalInfantCount()
        {
            int _infantCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (room.Child == null)
                        break;
                    foreach (Person person in room.Child)
                    {
                        _infantCount += (person.Age < 2 ? 1 : 0);
                    }
                }
            }
            return _infantCount;
        }

        public int GetSingleRoomCount()
        {
            int _singleCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (room.Adult?.Count == 1)
                        _singleCount++;
                }
            }
            return _singleCount;
        }

        public int GetDoubleRoomCount()
        {
            int _doubleCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (room.Adult?.Count == 2)
                        _doubleCount++;
                }
            }
            return _doubleCount;
        }

        public int GetTripleRoomCount()
        {
            int _tripleCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (room.Adult?.Count == 3)
                        _tripleCount++;
                }
            }
            return _tripleCount;
        }

        public int GetQuadRoomCount()
        {
            int _tripleCount = 0;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (room.Adult?.Count == 4)
                        _tripleCount++;
                }
            }
            return _tripleCount;
        }

        public bool isSingleWithChild()
        {
            bool flag = false;
            foreach (Room room in Rooms)
            {
                flag = (room.Child?.Count > 0 && room.Adult?.Count == 1);
            }
            return flag;
        }

        public bool isDoubleWithChild()
        {
            bool flag = false;
            foreach (Room room in Rooms)
            {
                flag = (room.Child?.Count > 0 && room.Adult?.Count == 2);
            }
            return flag;
        }

        public bool isTripleleWithChild()
        {
            bool flag = false;
            foreach (Room room in Rooms)
            {
                flag = (room.Child?.Count > 0 && room.Adult?.Count == 3);
            }
            return flag;
        }

        public int GetMinChildAge()
        {
            int minAge = int.MaxValue;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (minAge > room.MinChildAge())
                        minAge = room.MinChildAge();
                }
            }
            return minAge;
        }

        public int GetMaxChildAge()
        {
            int maxAge = int.MinValue;
            if (Rooms != null)
            {
                foreach (Room room in Rooms)
                {
                    if (maxAge < room.MaxChildAge())
                        maxAge = room.MaxChildAge();
                }
            }
            return maxAge;
        }

        public int GetTotalTravelerCount() => this.GetTotalAdultCount() + this.GetTotalChildCount();
    }
}
