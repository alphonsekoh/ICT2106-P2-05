using PainAssessment.Interfaces;
using PainAssessment.Models;
using System.Collections.Generic;

namespace PainAssessment.Domain
{
    public class DefaultQuestionService : IDefaultQuestionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DefaultQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateDefaultQuestion(int templateID, string questionString, string questionDescription, int painSection, double weightage)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDefaultQuestion(int defaultQuestionID)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DefaultQuestion> GetAllDefaultQuestions()
        {
            return _unitOfWork.DefaultQuestionRepository.GetAll();
        }

        public IEnumerable<DefaultQuestion> GetAllDefaultQuestionsFromTemplateChecklist(int templateID)
        {
            // TODO implement return table by id
            //IEnumerable<DefaultQuestion> tempArr = _unitOfWork.DefaultQuestionRepository.GetAll();
            //foreach(var entry in tempArr)
            //{
            //    if(entry.TCID == templateID)
            //    {

            //    }
            //}
            return _unitOfWork.DefaultQuestionRepository.GetAll();
        }

        public DefaultQuestion GetDefaultQuestion(int templateID)
        {
            return _unitOfWork.DefaultQuestionRepository.GetById(templateID);
        }

        public void UpdateDefaultQuestion(int defaultQuestionID, string questionString, string questionDescription, int painSection, double weightage)
        {
            DefaultQuestion temp = GetDefaultQuestion(defaultQuestionID);
            temp.QString = questionString;
            temp.QDescription = questionDescription;
            temp.PainSection = painSection;
            temp.Weightage = weightage;
            _unitOfWork.Save();
        }
    }
}
