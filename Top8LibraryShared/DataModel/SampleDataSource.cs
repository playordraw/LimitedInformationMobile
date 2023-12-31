// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// File: SampleDataSource.cs
//
// Copyright (c) 2023 Jeffrey Reynolds
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

//using Windows.Data.Json;
//using Windows.Storage;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace Top8Library.Data
{
    /// <summary>
    ///     Generic item data model.
    /// </summary>
    public class SampleDataItem
    {
        public SampleDataItem(string uniqueId, string title, string subtitle, string imagePath, string description, string content)
        {
            UniqueId = uniqueId;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            ImagePath = imagePath;
            Content = content;
        }

        public string UniqueId {get;}
        public string Title {get;}
        public string Subtitle {get;private set;}
        public string Description {get;private set;}
        public string ImagePath {get;private set;}
        public string Content {get;private set;}

        public override string ToString()
        {
            return Title;
        }
    }

    /// <summary>
    ///     Generic group data model.
    /// </summary>
    public class SampleDataGroup
    {
        public SampleDataGroup(string uniqueId, string title, string subtitle, string imagePath, string description)
        {
            UniqueId = uniqueId;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            ImagePath = imagePath;
            Items = new ObservableCollection<SampleDataItem>();
        }

        public string UniqueId {get;}
        public string Title {get;}
        public string Subtitle {get;private set;}
        public string Description {get;private set;}
        public string ImagePath {get;private set;}
        public ObservableCollection<SampleDataItem> Items {get;}

        public override string ToString()
        {
            return Title;
        }
    }

    /// <summary>
    ///     Creates a collection of groups and items with content read from a static json file.
    ///     SampleDataSource initializes with data read from a static json file included in the
    ///     project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static readonly SampleDataSource _sampleDataSource = new SampleDataSource();

        public ObservableCollection<SampleDataGroup> Groups {get;} = new ObservableCollection<SampleDataGroup>();

        public static async Task<IEnumerable<SampleDataGroup>> GetGroupsAsync()
        {
            await _sampleDataSource.GetSampleDataAsync();

            return _sampleDataSource.Groups;
        }

        public static async Task<SampleDataGroup> GetGroupAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.Where(group => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<SampleDataItem> GetItemAsync(string uniqueId)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.Groups.SelectMany(group => group.Items).Where(item => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetSampleDataAsync()
        {
            if (Groups.Count != 0)
                return;

            var dataUri = new Uri("ms-appx:///DataModel/SampleData.json");

            //StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            //string jsonText = await FileIO.ReadTextAsync(file);
            //JsonObject jsonObject = JsonObject.Parse(jsonText);
            //JsonArray jsonArray = jsonObject["Groups"].GetArray();

            //foreach (JsonValue groupValue in jsonArray)
            //{
            //    JsonObject groupObject = groupValue.GetObject();
            //    SampleDataGroup group = new SampleDataGroup(groupObject["UniqueId"].GetString(),
            //                                                groupObject["Title"].GetString(),
            //                                                groupObject["Subtitle"].GetString(),
            //                                                groupObject["ImagePath"].GetString(),
            //                                                groupObject["Description"].GetString());

            //    foreach (JsonValue itemValue in groupObject["Items"].GetArray())
            //    {
            //        JsonObject itemObject = itemValue.GetObject();
            //        group.Items.Add(new SampleDataItem(itemObject["UniqueId"].GetString(),
            //                                           itemObject["Title"].GetString(),
            //                                           itemObject["Subtitle"].GetString(),
            //                                           itemObject["ImagePath"].GetString(),
            //                                           itemObject["Description"].GetString(),
            //                                           itemObject["Content"].GetString()));
            //    }
            //    this.Groups.Add(group);
            //}
        }
    }
}
