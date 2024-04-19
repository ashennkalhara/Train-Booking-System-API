using System.Collections.Generic;
using System.Linq;
using TrainAPI.Model;
using TrainAPI.Data;

namespace TrainAPI.Data
{
    public class TrainRepository
    {
        private AppDBContext dbContext;

        public TrainRepository(AppDBContext context)
        {
            dbContext = context;
        }

        public bool CreateTrain(Train train)
        {
            if (train != null)
            {
                dbContext.trains.Add(train);
                return Save();
            }
            else
                return false;
        }

        public bool Save()
        {
            int count = dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool UpdateTrain(Train train)
        {
            dbContext.trains.Update(train);
            return Save();
        }

        public bool RemoveTrain(Train train)
        {
            dbContext.trains.Remove(train);
            return Save();
        }

        public Train GetTrain(int id)
        {
            return dbContext.trains.FirstOrDefault(train => train.TrainId == id);
        }

        public IEnumerable<Train> GetTrains()
        {
            return dbContext.trains.ToList();
        }

        public IEnumerable<Train> SearchTrains(string startStation, string destinationStation, string date)
        {
            return dbContext.trains
                .Where(train => train.StartStation == startStation && train.DestinationStation == destinationStation && train.Date == date)
                .ToList();
        }
    }
}
