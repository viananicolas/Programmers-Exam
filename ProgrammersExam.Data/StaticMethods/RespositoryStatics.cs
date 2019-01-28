using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProgrammersExam.Data.UnitOfWork.Interface;
using ProgrammersExam.Entities.Entity;

namespace ProgrammersExam.Data.StaticMethods
{
    public static class RespositoryStatics
    {
        public static async Task<Play> RetrievePlay(int id, IUnitOfWork unitOfWork)
        {
            return await unitOfWork.GetRepositoryAsync<Play>().SingleAsync(play => play.Id == id);
        }
    }
}
