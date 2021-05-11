using HamuaRegistrationApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Services.Communication
{
    public class SaveTangataResponse : BaseResponse
    {
        public Tangata Tangata { get; private set; }

        private SaveTangataResponse(bool success, string message, Tangata tangata) : base(success, message)
        {
            Tangata = tangata;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveTangataResponse(Tangata tangata) : this(true, string.Empty, tangata)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveTangataResponse(string message) : this(false, message, null)
        { }
    }
}