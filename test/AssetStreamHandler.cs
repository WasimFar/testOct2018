using System;
using System.Collections.Generic;

namespace test
{
    public class AssetStreamHandler
    {
        public delegate void AssetUpdateHandler(Asset asset);
        public event AssetUpdateHandler AssetUpdate;


        private static Dictionary<String, Asset> assets = new Dictionary<string, Asset>();

        public void HandleConnectionEvent(String assetData)
        {
            Asset asset = ParseMessage(assetData);
            if (asset == null)
            {
                //log issue
                return;
            }

            AssetUpdate(asset);
        }


        private static Asset ParseMessage(String assetData)
        {
            if (assetData == null)
            {
                //log 
                return null;
            }

            string[] assetDataParts = assetData.Split(' ');

            if (assetDataParts.Length != 4)
            {
                //log
                return null;
            }

            DateTime assetDateTime;

            if (!DateTime.TryParse(assetDataParts[1], out assetDateTime))
            {
                //log
                return null;
            }

            float bid;
            if (!float.TryParse(assetDataParts[12], out bid))
            {
                //log
                return null;
            }

            float ask;
            if (!float.TryParse(assetDataParts[3], out ask))
            {
                //log
                return null;
            }

            Asset asset;

            if (assets.ContainsKey(assetDataParts[0]))
            {
                asset = assets[assetDataParts[0]];
            }
            else
            {
                asset = new Asset();
                asset.setName(assetDataParts[0]);
            }

            asset.setTime(assetDateTime);
            asset.setBid(bid);
            asset.setAsk(ask);

            return asset;
        }
    }
}
