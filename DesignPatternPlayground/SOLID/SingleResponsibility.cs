using System;

namespace DesignPatternPlayground.SOLID
{

    // Principle is related to Designing software module, class or function that should perform only 
    // one task.So this principle is about Creation.
    public class SingleResponsibility
    {

        public void Add()
        {
            try
            {

            }
            catch (Exception ex)
            {

                ErrorHandler obj = new ErrorHandler();
                obj.HandleError(ex);
            }    

        }
    }

    public class ErrorHandler
    {
        public void HandleError(Exception error)
        {
            
        }
    }
}
