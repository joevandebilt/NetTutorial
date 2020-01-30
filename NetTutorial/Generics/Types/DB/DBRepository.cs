using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.DB
{
    public static class Service 
    {
        /* This is a generic Save - we don't know if this entity exists or not yet so we need to insert it if it's new, or update if it exists
         * 
         * But there's an issue - we don't know that type T has an ID because it's too generic, so we decorate the method a little more to let
         * the method know that type T is a baseEntity, and then it knows that it can make use of those fields 
         *
         */
        public static bool Save<T>(T dbEntity) where T : BaseEntity
        {
            try
            {
                //Create a repository that will do the Data stuff, SQL, Entity Framework, storing shit in a text file - whatever
                var repository = new Repository<T>();

                //Now asess what we need to do
                if (dbEntity.ID > 0)
                {
                    //The ID isn't default, so this is an updated
                    dbEntity.UpdatedOn = DateTime.Now;
                    dbEntity.UpdatedBy = Guid.NewGuid(); //normally this will be somebodies actual identity

                    repository.Update(dbEntity);
                    return true;
                }
                else
                {
                    //The ID is 0 so we need to insert this record
                    dbEntity.CreatedOn = DateTime.Now;
                    dbEntity.CreatedBy = Guid.NewGuid(); //normally this will be somebodies actual identity
                    dbEntity.UpdatedOn = DateTime.Now;
                    dbEntity.UpdatedBy = Guid.NewGuid(); //normally this will be somebodies actual identity

                    repository.Insert(dbEntity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    /* 
     * Note that this repository inherits type T and passes this onto the Interface
     * 
     * The interface defines the repo and says you must be able to Insert, Update and Delete objects of Type T
     * 
     * The Repositories job is to carry out those actions and return the right stuff - the interface doesn't care how it's done
     * 
     * Notice again that we've declared T is a BaseEntity
     */
     
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public bool Delete(T recordToDelete)
        {
            //I've deleted the record
            return true;
        }

        public int Insert(T newRecord)
        {
            //I've saved the element and gotten an ID back
            newRecord.ID = new Random().Next(2, 100);
            return newRecord.ID;
        }

        public int Update(T existingRecord)
        {
            //I've updated the record and gotten back a number of existing records
            return 1;
        }
    }
}
