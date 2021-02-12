using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Blender {
    public class Model {

        //=====================================================================
        // CONSTRUCTORS
        //=====================================================================

        public Model() { }

        //=====================================================================
        // PROPERTIES
        //=====================================================================

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public string FullInfo {
            get {
                return $"{ID}                   {Name}                 {UserName}                   {Created}";
            }
        }

        public string deletetrialgetter {
            get {
                return $"{ID}";
            }
        }
    }
}