﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mytemize
{
    /**
     * Enum of different states acceptable by a mytemize record
     */
    internal enum RecordState
    {
        INCOMPLETE,
        COMPLETE,
        PARTIAL
    }

    /**
     * MZRecord - keeps an entry of a MZList including its id, description and state
     */
    internal class MZRecord
    {
        // these properties are set to Public since newtonsoft's json converter can't build objects out of deserialized json properly if they weren't public
        public int id, stateInt;
        public string description;
        public RecordState state;
        public DateTime schedule;
        public bool allowPartial = false, isScheduled = false;

        // getters & setters
        [JsonIgnore]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonIgnore]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [JsonIgnore]
        public RecordState State {
            get { return state; }
        }

        [JsonIgnore]
        public int StateInt
        {
            get { return stateInt; }
        }

        [JsonIgnore]
        public bool AllowPartial
        {
            get { return allowPartial; }
            set { allowPartial = value; }
        }

        [JsonIgnore]
        public bool IsScheduled
        {
            get { return isScheduled; }
            set { isScheduled = value; }
        }

        [JsonIgnore]
        public DateTime Schedule
        {
            get { return schedule; }
            set { schedule = value.Date; }
        }

        public int setState
        {
            set
            {
                if (value == 0) state = RecordState.INCOMPLETE;
                else if (value == 1) state = RecordState.COMPLETE;
                else if (value == 2) state = RecordState.PARTIAL;
                setIntState();
            }
        }

        // constructor. ID is required everytime a record is created
        public MZRecord(int iID, string desc = "", RecordState rState = RecordState.INCOMPLETE, bool stateType = false, bool hasSchedule = false, DateTime? date = null)
        {
            id = iID;
            description = desc;
            allowPartial = stateType;
            state = rState;
            setIntState();

            isScheduled = hasSchedule;
            if (date.HasValue) schedule = date.Value;
            else schedule = DateTime.Now;
        }

        private void setIntState()
        {
            stateInt = 0;
            if (state == RecordState.COMPLETE) stateInt = 1;
            else if (state == RecordState.PARTIAL) stateInt = 2;
        }
    }

    /**
     * MZList - the bread and butter of the program. This is the root class of a Mytemize file generated by the Mytemize editor
     * - Keeps MZRecords as entries
     */
    internal class MZList
    {
        public string title;
        public List<MZRecord> items;
        public int count;

        // getters and setters
        [JsonIgnore]
        public int Count
        {
            get { return items.Count; }
        }

        [JsonIgnore]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [JsonIgnore]
        public List<MZRecord> Records
        {
            get { return items; }
        }

        // constructor
        public MZList()
        {
            items = new List<MZRecord>();
            count = items.Count;
        }

        /**
         * Record actions here
         */
        // Add a new record
        public bool addRecord(string desc)
        {
            bool val = false;
            MZRecord item = new MZRecord(items.Count + 1, desc, 0);
            if (item != null) {
                items.Add(item);
                count = items.Count;
                val = true; // set to true if successful
            }
            return val;
        }

        // get the current record at a given index
        public MZRecord getRecordById(int id)
        {
            MZRecord item = null;
            item = items.FirstOrDefault(i => i.ID == id);

            return item;
        }

        // get the latest record found, or return null if no records available yet
        public MZRecord getRecordLatest()
        {
            if (items.Count <= 0) return null;
            return items[items.Count-1];
        }

        // remove specific record with ID
        public bool removeRecordById(int id)
        {
            bool removed = false;
            MZRecord item = null;
            item = items.FirstOrDefault(i => i.ID == id);

            // If not null, then we found the item and can remove it
            if (item != null)
            {
                Debug.WriteLine("Removing Item: " + item.ID);
                items.Remove(item);
                count = items.Count;
                removed = true;
            }
            else
            {
                Debug.WriteLine("Record with " + id + " not found.");
            }

            return removed;
        }

        // calculate how many of the entries have been set to complete and return its value
        public float checkProgress()
        {
            if (items.Count <= 0) return 100f; // return full count if there are no entries because why would there be any progress on it?

            float done = 0f;

            for (int i = 0; i < items.Count; i++)
            {
                // only consider complete states as "done" - partial and incomplete should still be inc
                if (items[i].State == RecordState.COMPLETE) done++;
            }

            // Math.Max ensures we don't get 0 on lists with only one entry
            return 100 * done / Math.Max(1, (items.Count));
        }

        // return how many entries have been completed
        public int checkCompletedEntries()
        {
            if (items.Count <= 0) return 0; // return full count if there are no entries because why would there be any progress on it?

            int done = 0;

            for (int i = 0; i < items.Count; i++)
            {
                // only consider complete states as "done" - partial and incomplete should still be inc
                if (items[i].State == RecordState.COMPLETE) done++;
            }

            // Math.Max ensures we don't get 0 on lists with only one entry
            return done;
        }

    }

    /**
     * Import Settings - A settings class used to refer to how an Import File should parse the data within the file like CSV or XLS
     * 
     */
    internal class ImportSettings
    {
        const string FILETYPE_CSV = "CSV", FILETYPE_XLS = "XLS", EMPTYCELL = "$$_EMPTY_$$";

        public string fileType, importType;

        public int targetColumn, targetRow;
        public Tuple<int, int> grpStartCell, grpEndCell;

        public ImportSettings(string filetype, string importtype = "ALL", int row = 0, int col = 0, int fromCellRow = 0, int fromCellCol = 0, int toCellRow = 0, int toCellCol = 0)
        {
            fileType = filetype.ToUpper();
            importType = importtype.ToUpper();

            targetRow = row;
            targetColumn = col;
            grpStartCell = new Tuple<int, int>(fromCellRow, fromCellCol);
            grpEndCell = new Tuple<int, int>(toCellRow, toCellCol);
        }
    }
}
