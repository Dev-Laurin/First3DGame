using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTime
{
    private List<string> season = new List<string>{"Spring", "Summer", "Fall", "Winter"}; 
    private List<string> days = new List<string>{"Sunday", "Monday", "Tuesday", "Wednesday", 
    "Thursday", "Friday", "Saturday"}; 
    private List<string> timeOfDay = new List<string>{"AM", "PM"}; 

    private int currentHour; 
    private int currentMin; 
    private int currentTimeOfDay; 
    private int currentDay; 
    private int previousTimeOfDay; 
    private int currentDayOfSeason; 
    private int currentSeason; 

    public DateTime(){
        currentDay = 0; 
        currentHour = 8; 
        currentMin = 0; 
        currentTimeOfDay = 0; 
        currentDayOfSeason = 1; 
        currentSeason = 0; 
    }

    //updates time incrementally - to be called by the update function. 
    public void PassTime(){
        currentMin += 10; 

        //go to next hour
        if(currentMin >= 60){
            currentHour += 1;
            currentMin = 0; 

            //if it is now past 12 PM change to 1 PM 
            if(currentHour > 12 && currentTimeOfDay == 1 && currentMin == 0){
                currentHour = 1; 
            }

            //go to next day
            if(currentHour > 11 && currentTimeOfDay == 1){
                currentDay += 1; 
                currentDayOfSeason += 1; 
                //reset to beg of week 
                if(currentDay >= days.Count){
                    currentDay = 0; 
                }
                currentHour = 0; 
                currentTimeOfDay = 0; 
            }
        }

        //assuming 12 AM is already converted to 0 AM
        if(currentHour == 12){
            currentTimeOfDay = 1; //change to PM 
        }

        //change seasons
        if(currentDayOfSeason > 31){
            currentSeason += 1; 
            if(currentSeason >= season.Count){
                currentSeason = 0; 
            }
            currentDayOfSeason = 1; 
        }
    }

    public string GetDateTime(){
        string prettyMin = currentMin.ToString(); 
        if(currentMin == 0){
            prettyMin = "00"; 
        }
        return days[currentDay] + " " + currentHour + ":" + prettyMin + timeOfDay[currentTimeOfDay]; 
    }

    public string GetDayOfSeason(){
        return season[currentSeason] + " " + "Day " + currentDayOfSeason; 
    }

    //Go to next day (sleep)
    public void NextDay(){

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
