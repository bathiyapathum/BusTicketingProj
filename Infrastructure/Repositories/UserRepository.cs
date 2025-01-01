using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Google.Cloud.Firestore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FirestoreDb _firestoreDb;
        public UserRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var usersCollection = _firestoreDb.Collection("users"); // Assuming "users" is your Firestore collection
            var query = usersCollection.WhereEqualTo("Email", email);
            var snapshot = await query.GetSnapshotAsync();

            var userDocument = snapshot.Documents.FirstOrDefault();
            if (userDocument != null)
            {
                return userDocument.ConvertTo<User>(); // Convert Firestore document to your User object
            }

            return null; // Or throw an exception if you prefer
        }

        // Method to register a new user in Firestore
        public async Task RegisterUserAsync(User user)
        {
            var usersCollection = _firestoreDb.Collection("users"); // Assuming "users" is your Firestore collection
            var docRef = usersCollection.Document(); // Firestore auto-generates a unique document ID
            await docRef.SetAsync(user); // Save the user to Firestore
        }

    }
}
