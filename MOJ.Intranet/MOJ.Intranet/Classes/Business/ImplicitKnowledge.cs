using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.Business
{
    public class ImplicitKnowledge
    {
        public List<VoluntaryWorkEntity> GetVoluntaryWork(string title)
        {
            return new ImplicitKnowledgeDataManager().GetVoluntaryWork(title);

        }
        public bool SaveUpdateVoluntaryWork(List<VoluntaryWorkEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateVoluntaryWork(obj);

        }
        public List<HopisEntity> GetHopis(string title)
        {
            return new ImplicitKnowledgeDataManager().GetHopis(title);

        }
        public bool SaveUpdateHopis(List<HopisEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateHopis(obj);

        }
        public List<MembershipEntity> GetMembership(string title)
        {
            return new ImplicitKnowledgeDataManager().GetMembership(title);

        }
        public bool SaveUpdateMembership(List<MembershipEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateMembership(obj);

        }
        public List<ParticipationsEntity> GetParticipations(string title)
        {
            return new ImplicitKnowledgeDataManager().GetParticipations(title);

        }
        public bool SaveUpdateParticipations(List<ParticipationsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateParticipations(obj);

        }
        public DataTable GetCountrys()
        {
            return new CountrysDataManager().GetAll();
        } public DataTable Getlevels()
        {
            return new levelsDataManager().GetAll();
        }
        public int SaveUpdate(ImplicitKnowledgeEntity obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateRequest(obj);
        }
        public bool SaveUpdateEmploymentHistory(List<EmploymentHistoryEntity> obj)
        {
           return new ImplicitKnowledgeDataManager().AddOrUpdateEmploymentHistory(obj);

        }
        public List<EmploymentHistoryEntity> GeteEmploymentHistory(string title)
        {
           return new ImplicitKnowledgeDataManager().GeteEmploymentHistory(title);

        }
        public List<QualificationsEntity> GeteQualifications(string title)
        {
            return new ImplicitKnowledgeDataManager().GeteQualifications(title);

        }
        public List<TravelInformationsEntity> GetTravelInformations(string title)
        {
            return new ImplicitKnowledgeDataManager().GetTravelInformations(title);

        }
        public List<PublicationsEntity> GetPublications(string title)
        {
            return new ImplicitKnowledgeDataManager().GetPublications(title);

        }
        public List<ExpertiseEntity> GeteExpertise(string title)
        {
            return new ImplicitKnowledgeDataManager().GetExpertise(title);

        }
        public List<TrainingCoursesEntity> GetTrainingCourses(string title)
        {
            return new ImplicitKnowledgeDataManager().GetTrainingCourses(title);

        }
        public List<LanguageSkillsEntity> GeteLanguageSkills(string title)
        {
            return new ImplicitKnowledgeDataManager().GeteLanguageSkills(title);

        }
        public List<TechnicalSkillsEntity> GeteTechnicalSkills(string title)
        {
            return new ImplicitKnowledgeDataManager().GetTechnicalSkills(title);

        }
         public List<OtherSkillsEntity> GeteOtherSkills(string title)
        {
            return new ImplicitKnowledgeDataManager().GetOtherSkills(title);

        }
        


        public ImplicitKnowledgeEntity GetImplicitKnowledge(string title)
        {
            return new ImplicitKnowledgeDataManager().GetImplicitKnowledge(title);

        }

        
            public bool DeleteitemsFromSublist(string listname , List<int> listsid )
        {
            return new ImplicitKnowledgeDataManager().DeleteitemsFromSublist(listname, listsid);

        }

        public bool SaveUpdateQualifications(List<QualificationsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateQualifications(obj);

        }
        public bool SaveUpdateTravelInformations(List<TravelInformationsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateTravelInformations(obj);

        }
        public bool SaveUpdateExpertise(List<ExpertiseEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateExpertise(obj);

        }
        public bool SaveUpdateTrainingCourses(List<TrainingCoursesEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateTrainingCourses(obj);

        }
        public bool SaveUpdatePublications(List<PublicationsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdatePublications(obj);

        }
        public bool SaveUpdateLanguageSkills(List<LanguageSkillsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateLanguageSkills(obj);

        }

        public bool SaveUpdateTechnicalSkills(List<TechnicalSkillsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateTechnicalSkills(obj);

        }
         public bool SaveUpdateOtherSkills(List<OtherSkillsEntity> obj)
        {
            return new ImplicitKnowledgeDataManager().AddOrUpdateOtherSkills(obj);

        }


        //public AffirmationSocialSituationEntity GetAffirmationSocialSituation(int id)
        //{
        //    return new AffirmationSocialSituationDataManager().GetAffirmationSocialSituationByID(id);
        //}


        //    public List<HusbandORWifeEntity> GetHusbandORWife(string title)
        //{
        //    return new HusbandORWifeDataManager().GetHusbandORWife(title);
        //}

        // public List<SonsEntity> Getsons(string title)
        //{
        //    return new SonsDataManager().Getsons(title);
        //}


    }
}
