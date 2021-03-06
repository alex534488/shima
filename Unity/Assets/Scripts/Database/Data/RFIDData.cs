﻿public class RFIDData {

	public string timestamp { get; set; }
	public string antenaId { get; set; }
	public float signalStrength { get; set; }
	public string tagId { get; set; }

	public RFIDData (string timestamp, string antenaId, float signalStrength, string tagId)
	{
		this.timestamp = timestamp;
		this.antenaId = antenaId;
		this.signalStrength = signalStrength;
		this.tagId = tagId;
	}
	

	public override string ToString ()
	{
		return string.Format ("[RFIDData: Timestamp={0}, AntenaId={1},  SignalStrength={2}, TagId={3}]", timestamp, antenaId, signalStrength, tagId);
	}

}
