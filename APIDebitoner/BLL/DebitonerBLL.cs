using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDebitoner.DAL;


namespace APIDebitoner.BLL
{
    public class DebitonerBLL
    {
        DebitonerDAL DebitonerDAL = new DebitonerDAL();

        public List<Debitoner> GetAllDebitoner()
        {
            return DebitonerDAL.GetAllDebitoner();
        }
        public Debitoner GetDebitionerByID(int debitonerId)
        {
            if(debitonerId <= 0)
                throw new ArgumentException("DebitonerId need to be higher that 0.");
            return DebitonerDAL.GetDebitonerById(debitonerId);
        }
    }
}
