using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PetAdoptionWebsite.Models
{
    public class PetSession
    {
        private const string PetListKey = "PetList";
        private const string CountKey = "PetCount";
        private const string FavoritesKey = "UserFavorites";

        private ISession session;

        public PetSession(ISession session)
        {
            this.session = session;
        }

        public void SetPetList(List<Pet> petList)
        {
            try
            {
                session.SetObject(PetListKey, petList);
                session.SetInt32(CountKey, petList.Count);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display, or rethrow)
                Debug.WriteLine($"Error setting pet list in session: {ex.Message}");
            }
        }

        public List<Pet> GetMyPets()
        {
            try
            {
                return session.GetObject<List<Pet>>(PetListKey) ?? new List<Pet>();
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display, or rethrow)
                Debug.WriteLine($"Error getting pet list from session: {ex.Message}");
                return new List<Pet>();
            }
        }

        public int GetMyPetCount()
        {
            try
            {
                return session.GetInt32(CountKey) ?? 0;
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display, or rethrow)
                Debug.WriteLine($"Error getting pet count from session: {ex.Message}");
                return 0;
            }
        }

        public void RemoveMyPets()
        {
            try
            {
                session.Remove(PetListKey);
                session.Remove(CountKey);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display, or rethrow)
                Debug.WriteLine($"Error removing pet list from session: {ex.Message}");
            }
        }
    }
}
