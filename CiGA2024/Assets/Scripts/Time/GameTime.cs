using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameTime : IComparable<GameTime>
{
    public int Month = 5;
    public int Day = 11;
    public int DayOfTheWeek; // 1 = Monday, 2 = Tuesday, ..., 7 = Sunday
    public int GameDay = 1;
    public int Hour = 0;
    public int Minute = 0;

    [Header ("Time Speed")]
    public float TimeSpeed = 1.0f;
    public int SpeedLevel; // 0 = 1x, 1 = 2x, 2 = 3x, 3 = 4x

    //Constructor
    public GameTime(int month, int day, int gameday, int dayOfTheWeek, int hour, int minute)
    {
        Month = month;
        Day = day;
        GameDay = gameday;
        DayOfTheWeek = dayOfTheWeek;
        Hour = hour;
        Minute = minute;
    }

    public GameTime(int hour, int minute){
        Month = 1;
        Day = 1;
        GameDay = 1;
        DayOfTheWeek = 1;
        Hour = hour;
        Minute = minute;
    }

    //Comparators
    public static bool operator <(GameTime a, GameTime b)
    {
        if (a.Hour < b.Hour)
        {
            return true;
        }
        else if (a.Hour == b.Hour)
        {
            if (a.Minute < b.Minute)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator >(GameTime a, GameTime b)
    {
        if (a.Hour > b.Hour)
        {
            return true;
        }
        else if (a.Hour == b.Hour)
        {
            if (a.Minute > b.Minute)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator ==(GameTime a, GameTime b)
    {
        if (a.Hour == b.Hour && a.Minute == b.Minute)
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(GameTime a, GameTime b)
    {
        if (a.Hour != b.Hour || a.Minute != b.Minute)
        {
            return true;
        }
        return false;
    }

    public static bool operator <=(GameTime a, GameTime b)
    {
        return a < b || a == b;
    }

    public static bool operator >=(GameTime a, GameTime b)
    {
        return a > b || a == b;
    }

    public static GameTime operator +(GameTime a, GameTime b)
    {
        int newHour = a.Hour + b.Hour;
        int newMinute = a.Minute + b.Minute;
        if (newMinute >= 60)
        {
            newHour++;
            newMinute -= 60;
        }
        return new GameTime(newHour, newMinute);
    }

    public static GameTime operator -(GameTime a, GameTime b)
    {
        int newHour = a.Hour - b.Hour;
        int newMinute = a.Minute - b.Minute;
        if (newMinute < 0)
        {
            newHour--;
            newMinute += 60;
        }
        return new GameTime(newHour, newMinute);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        GameTime other = (GameTime)obj;
        return Hour == other.Hour && Minute == other.Minute;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Hour.GetHashCode();
            hash = hash * 23 + Minute.GetHashCode();
            return hash;
        }
    }

    public override string ToString()
    {
        return string.Format("{0}:{1}", Hour, Minute);
    }

    public string GetChineseTimeOfTheWeek(){
        switch(DayOfTheWeek){
            case 1:
                return "一";
            case 2:
                return "二";
            case 3:
                return "三";
            case 4:
                return "四";
            case 5:
                return "五";
            case 6:
                return "六";
            case 7:
                return "日";
            default:
                return "星期一";
        }
    }

    public int CompareTo(GameTime other)
    {
        if (this.Hour < other.Hour)
        {
            return -1;
        }
        else if (this.Hour > other.Hour)
        {
            return 1;
        }
        else
        {
            if (this.Minute < other.Minute)
            {
                return -1;
            }
            else if (this.Minute > other.Minute)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

[System.Serializable]
public struct TimePair{
    public int hour;
    public int minute;
}


