﻿#region License
/*
    This source makes up part of JiraToTfs, a utility for migrating Jira
    tickets to Microsoft TFS.

    Copyright(C) 2016  Ian Montgomery

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.If not, see<http://www.gnu.org/licenses/>.
*/
#endregion

using System.Linq;

namespace TicketImporter
{
    public class TfsFieldMap
    {
        public TfsFieldMap(TfsFieldCollection fields)
        {
            this.fields = fields;

            if (this.fields != null)
            {
                var storedMap = SettingsStore.Load(key);
                foreach (var fieldName in this.fields.Names)
                {
                    this.fields[fieldName].DefaultValue = storedMap.ContainsKey(fieldName) == false ? "" : storedMap[fieldName];
                }
            }
        }

        public TfsFieldCollection Fields
        {
            get { return fields; }
        }

        public void Save()
        {
            var map = fields.Names.ToDictionary(name => name, name => fields[name].DefaultValue);
            SettingsStore.Save(key, map);
        }

        #region private class members
        private readonly TfsFieldCollection fields;
        private const string key = "TfsFieldValues";
        #endregion
    }
}