using HamuaRegistrationApi.DAL.Interfaces;
using HamuaRegistrationApi.DAL.Models;
using HamuaRegistrationApi.DAL.Services.Communication;
using HamuaRegistrationApi.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Implementations
{
    public class TangataService : ITangataService
    {
        public ITangataProvider tangataProvider;
        public IUnitOfWork tangataUnitOfWork;

        public TangataService(ITangataProvider provider, IUnitOfWork unitOfWork)
        {
            tangataProvider = provider;
            tangataUnitOfWork = unitOfWork;
        }

        public Task<Tangata> AddChild(Tangata newTangata, int parentId)
        {
            throw new NotImplementedException();
        }

        public async Task<TangataResponse> CreateTangataAsync(Tangata newTangata, IEnumerable<int> ngaMarae, int parentId = 0, int childId = 0)
        {
            try
            {
                await tangataProvider.AddAsync(newTangata, ngaMarae);
                await tangataUnitOfWork.CompleteAsync();

                return new TangataResponse(newTangata);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TangataResponse($"An error occurred when saving the Tangata: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Tangata>> GetAllTangataAsync(string sortby = "", string searchString = "", bool includeMarae = false, bool includeChildren = false)
        {
            return await tangataProvider.GetAllTangataAsync(sortby, searchString, includeMarae, includeChildren);
        }

        public async Task<Tangata> GetTangataByIdAsync(int id, bool includeMarae = false, bool includeChildren = false)
        {
            return await tangataProvider.GetTangataByIdAsync(id, includeMarae, includeChildren);
        }

        public async Task<TangataResponse> UpdateTangataAsync(int id, Tangata editTangata, IEnumerable<int> ngaMarae)
        {
            var existingTangata = await tangataProvider.GetTangataByIdAsync(id, true);

            existingTangata.FirstName = editTangata.FirstName;
            existingTangata.LastName = editTangata.LastName;
            existingTangata.Gender = editTangata.Gender;
            existingTangata.DOB = editTangata.DOB;
            existingTangata.PlaceOfBirth = editTangata.PlaceOfBirth;
            existingTangata.Address1 = editTangata.Address1;
            existingTangata.Address2 = editTangata.Address2;
            existingTangata.Address3 = editTangata.Address3;
            existingTangata.Occupation = editTangata.Occupation;
            existingTangata.SpecialtySkills = editTangata.SpecialtySkills;
            existingTangata.PostCode = editTangata.PostCode;
            existingTangata.Country = editTangata.Country;
            existingTangata.HomePhone = editTangata.HomePhone;
            existingTangata.Mobile = editTangata.Mobile;
            existingTangata.Email = editTangata.Email;
            existingTangata.IsTeReoFirstLanguage = editTangata.IsTeReoFirstLanguage;
            existingTangata.CanYouSpeakTeReo = editTangata.CanYouSpeakTeReo;
            existingTangata.TeReoProficiency = editTangata.TeReoProficiency;
            existingTangata.ReturnComment = editTangata.ReturnComment;
            existingTangata.ReturnToRuatokiToLive = editTangata.ReturnToRuatokiToLive;
            existingTangata.Facebook = editTangata.Facebook;
            existingTangata.Twitter = editTangata.Twitter;
            existingTangata.Instagram = editTangata.Instagram;
            //existingTangata.NgaMarae = editTangata.NgaMarae;
            //existingTangata.Mother = editTangata.Mother;
            //existingTangata.Father = editTangata.Father;
            //existingTangata.Children = editTangata.Children;

            try
            {
                await tangataProvider.UpdateAsync(existingTangata, ngaMarae);
                await tangataUnitOfWork.CompleteAsync();

                return new TangataResponse(existingTangata);
            }
            catch (Exception ex)
            {
                return new TangataResponse($"Error Updating Tangata: {ex.Message}");
            }
        }
    }
}