using System;
using System.Collections.Generic;
using itk.simple;

namespace DicomFolderParser
{
    public class DicomParser
    {
        public Dictionary<string, VectorString> series_instance_uids = new Dictionary<string, VectorString>();
        public DicomParser()
        {
        }
        public void __reset__()
        {
            series_instance_uids = new Dictionary<string, VectorString>();
        }
        public void ParseDirectory(string directory)
        {
            VectorString dicom_series_ids = ImageSeriesReader.GetGDCMSeriesIDs(directory);
            foreach (string dicom_series_id in dicom_series_ids)
            {
                VectorString dicom_names = ImageSeriesReader.GetGDCMSeriesFileNames(directory, dicom_series_id);
                series_instance_uids.Add(dicom_series_id, dicom_names);
            }
        }
    }
}
