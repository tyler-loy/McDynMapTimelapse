using Newtonsoft.Json;

// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable ConditionIsAlwaysTrueOrFalse
// ReSharper disable RedundantJumpStatement
// ReSharper disable PartialTypeWithSinglePart
#pragma warning disable CS8603
#pragma warning disable CS8765
#pragma warning disable CS8618

namespace McDynMapTimelapse;

    public partial class DynMapConfig
    {
        [JsonProperty("updaterate")]
        public double Updaterate { get; set; }

        [JsonProperty("chatlengthlimit")]
        public long Chatlengthlimit { get; set; }

        [JsonProperty("components")]
        public Component[] Components { get; set; }

        [JsonProperty("worlds")]
        public World[] Worlds { get; set; }

        [JsonProperty("confighash")]
        public long Confighash { get; set; }

        [JsonProperty("spammessage")]
        public string Spammessage { get; set; }

        [JsonProperty("defaultmap")]
        public string Defaultmap { get; set; }

        [JsonProperty("msg-chatrequireslogin")]
        public string MsgChatrequireslogin { get; set; }

        [JsonProperty("msg-hiddennamejoin")]
        public string MsgHiddennamejoin { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("grayplayerswhenhidden")]
        public bool Grayplayerswhenhidden { get; set; }

        [JsonProperty("quitmessage")]
        public string Quitmessage { get; set; }

        [JsonProperty("defaultzoom")]
        public long Defaultzoom { get; set; }

        [JsonProperty("allowwebchat")]
        public bool Allowwebchat { get; set; }

        [JsonProperty("allowchat")]
        public bool Allowchat { get; set; }

        [JsonProperty("sidebaropened")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool Sidebaropened { get; set; }

        [JsonProperty("webchat-interval")]
        public double WebchatInterval { get; set; }

        [JsonProperty("msg-chatnotallowed")]
        public string MsgChatnotallowed { get; set; }

        [JsonProperty("loggedin")]
        public bool Loggedin { get; set; }

        [JsonProperty("coreversion")]
        public string Coreversion { get; set; }

        [JsonProperty("joinmessage")]
        public string Joinmessage { get; set; }

        [JsonProperty("webchat-requires-login")]
        public bool WebchatRequiresLogin { get; set; }

        [JsonProperty("showlayercontrol")]
        [JsonConverter(typeof(ParseStringConverter))]
        public bool Showlayercontrol { get; set; }

        [JsonProperty("login-enabled")]
        public bool LoginEnabled { get; set; }

        [JsonProperty("maxcount")]
        public long Maxcount { get; set; }

        [JsonProperty("dynmapversion")]
        public string Dynmapversion { get; set; }

        [JsonProperty("msg-maptypes")]
        public string MsgMaptypes { get; set; }

        [JsonProperty("cyrillic")]
        public bool Cyrillic { get; set; }

        [JsonProperty("msg-hiddennamequit")]
        public string MsgHiddennamequit { get; set; }

        [JsonProperty("msg-players")]
        public string MsgPlayers { get; set; }

        [JsonProperty("webprefix")]
        public string Webprefix { get; set; }

        [JsonProperty("showplayerfacesinmenu")]
        public bool Showplayerfacesinmenu { get; set; }

        [JsonProperty("defaultworld")]
        public string Defaultworld { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("spawnlabel", NullValueHandling = NullValueHandling.Ignore)]
        public string Spawnlabel { get; set; }

        [JsonProperty("spawnbedhidebydefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Spawnbedhidebydefault { get; set; }

        [JsonProperty("spawnbedformat", NullValueHandling = NullValueHandling.Ignore)]
        public string Spawnbedformat { get; set; }

        [JsonProperty("worldborderlabel", NullValueHandling = NullValueHandling.Ignore)]
        public string Worldborderlabel { get; set; }

        [JsonProperty("showworldborder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showworldborder { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("showlabel", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showlabel { get; set; }

        [JsonProperty("offlineicon", NullValueHandling = NullValueHandling.Ignore)]
        public string Offlineicon { get; set; }

        [JsonProperty("showspawnbeds", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showspawnbeds { get; set; }

        [JsonProperty("showofflineplayers", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showofflineplayers { get; set; }

        [JsonProperty("spawnbedicon", NullValueHandling = NullValueHandling.Ignore)]
        public string Spawnbedicon { get; set; }

        [JsonProperty("offlinehidebydefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Offlinehidebydefault { get; set; }

        [JsonProperty("offlinelabel", NullValueHandling = NullValueHandling.Ignore)]
        public string Offlinelabel { get; set; }

        [JsonProperty("enablesigns", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enablesigns { get; set; }

        [JsonProperty("default-sign-set", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultSignSet { get; set; }

        [JsonProperty("spawnicon", NullValueHandling = NullValueHandling.Ignore)]
        public string Spawnicon { get; set; }

        [JsonProperty("offlineminzoom", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offlineminzoom { get; set; }

        [JsonProperty("spawnbedminzoom", NullValueHandling = NullValueHandling.Ignore)]
        public long? Spawnbedminzoom { get; set; }

        [JsonProperty("showspawn", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showspawn { get; set; }

        [JsonProperty("spawnbedlabel", NullValueHandling = NullValueHandling.Ignore)]
        public string Spawnbedlabel { get; set; }

        [JsonProperty("maxofflinetime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Maxofflinetime { get; set; }

        [JsonProperty("allowurlname", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Allowurlname { get; set; }

        [JsonProperty("focuschatballoons", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Focuschatballoons { get; set; }

        [JsonProperty("showplayerfaces", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showplayerfaces { get; set; }

        [JsonProperty("sendbutton", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Sendbutton { get; set; }

        [JsonProperty("messagettl", NullValueHandling = NullValueHandling.Ignore)]
        public long? Messagettl { get; set; }

        [JsonProperty("hidebydefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidebydefault { get; set; }

        [JsonProperty("showplayerhealth", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showplayerhealth { get; set; }

        [JsonProperty("showplayerbody", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showplayerbody { get; set; }

        [JsonProperty("largeplayerfaces", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Largeplayerfaces { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("smallplayerfaces", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Smallplayerfaces { get; set; }

        [JsonProperty("layerprio", NullValueHandling = NullValueHandling.Ignore)]
        public long? Layerprio { get; set; }

        [JsonProperty("showdigitalclock", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showdigitalclock { get; set; }

        [JsonProperty("showweather", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Showweather { get; set; }

        [JsonProperty("show-mcr", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowMcr { get; set; }

        [JsonProperty("show-chunk", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowChunk { get; set; }

        [JsonProperty("hidey", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidey { get; set; }
    }

    public partial class World
    {
        [JsonProperty("sealevel")]
        public long Sealevel { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("maps")]
        public Map[] Maps { get; set; }

        [JsonProperty("extrazoomout")]
        public long Extrazoomout { get; set; }

        [JsonProperty("center")]
        public Center Center { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("worldheight")]
        public long Worldheight { get; set; }
    }

    public partial class Center
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("z")]
        public double Z { get; set; }
    }

    public partial class Map
    {
        [JsonProperty("nightandday")]
        public bool Nightandday { get; set; }

        [JsonProperty("shader")]
        public string Shader { get; set; }

        [JsonProperty("compassview")]
        public string Compassview { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("tilescale")]
        public long Tilescale { get; set; }

        [JsonProperty("icon")]
        public object Icon { get; set; }

        [JsonProperty("scale")]
        public long Scale { get; set; }

        [JsonProperty("azimuth")]
        public double Azimuth { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("backgroundday")]
        public object Backgroundday { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("mapzoomout")]
        public long Mapzoomout { get; set; }

        [JsonProperty("perspective")]
        public string Perspective { get; set; }

        [JsonProperty("worldtomap")]
        public double[] Worldtomap { get; set; }

        [JsonProperty("inclination")]
        public double Inclination { get; set; }

        [JsonProperty("image-format")]
        public string ImageFormat { get; set; }

        [JsonProperty("lighting")]
        public string Lighting { get; set; }

        [JsonProperty("bigmap")]
        public bool Bigmap { get; set; }

        [JsonProperty("maptoworld")]
        public double[] Maptoworld { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("boostzoom")]
        public long Boostzoom { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("backgroundnight")]
        public object Backgroundnight { get; set; }

        [JsonProperty("mapzoomin")]
        public long Mapzoomin { get; set; }
    }


    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (Boolean.TryParse(value, out b))
            {
                return b;
            }
            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

