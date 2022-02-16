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
            throw new System.NotImplementedException();
        }

        public DefaultQuestion GetDefaultQuestion(string templateID)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDefaultQuestion(int defaultQuestionID, string questionString, string questionDescription, int painSection, double weightage)
        {
            throw new System.NotImplementedException();
        }
    }
}
