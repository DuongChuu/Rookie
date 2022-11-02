using MVCD3.Models;

namespace MVCD3.Services
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> _people = new List<PersonModel>{
               new PersonModel( "Hải Dương","Chu", "Male",new DateTime(2000,01,11),"094962311","HaNoi",false ),
                new PersonModel( "Hường","Dương Thu", "Female",new DateTime(2001,12,11),"094962311","HaiDuong",true ),
                new PersonModel( "Thiều Anh","Phạm", "Female",new DateTime(2003,09,11),"094962311","BacGiang",false ),
                new PersonModel( "Hoàng Anh","Trịnh", "Male",new DateTime(2004,08,09),"094962311","HaiPhong",false ),
                new PersonModel( "Mạnh Hùng","Nguyễn", "Male",new DateTime(1999,01,01),"094962311","Hanoi",true )
        };
        public List<PersonModel> GetAll()
        {
            return _people;
        }
        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index <= _people.Count)
            {
                return _people[index];
            }

            return null;
        }

        public PersonModel Create(PersonModel model)
        {
            _people.Add(model);

            return model;
        }
        public PersonModel? Update(int index, PersonModel model)
        {
            if (index >= 0 && index <= _people.Count)
            {
                _people[index] = model;

                return model;
            }

            return null;
        }
        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index <= _people.Count)
            {
                var person = _people[index];
                _people.RemoveAt(index);

                return person;
            }

            return null;
        }
    }
}