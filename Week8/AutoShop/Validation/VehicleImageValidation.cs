using System.ComponentModel.DataAnnotations;

namespace AutoShop.Validation
{
    //To make your own validation you inherit from a class
    //called ValidationAttribute
    public class VehicleImageValidation : ValidationAttribute
    {
        //override the IsValid method
        public override bool IsValid(object value)
        {
            //the value is whatever got sent to the property that you are validating
            //cast it to whatever datatype it is
            IFormFile file = (IFormFile)value;
            //lets check that the file has a valid extension
            string[] validExtension = { ".jpg", ".gif", ".png" };
            //lets create a variable for max file size
            //3 mb biggest size
            int maxSize = 1024 * 1024 * 3;
            //first lets check for null
            if(file is null)
            {
                ErrorMessage = "Please upload a file";
                return false;
            }
            //lets make sure that the filename is a valid extension
            if (!validExtension.Contains(Path.GetExtension(file.FileName)))
            {
                ErrorMessage = $"Not an Image file. Please Upload {string.Join(",", validExtension)}";
                return false;
            }
            if(file.Length > maxSize)
            {
                ErrorMessage = "File is too large";
                return false;
            }
            //if we pass all of these return true
            return true;
        }
    }
}
