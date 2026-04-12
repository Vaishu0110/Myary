# Myary = My Personal Diary

## Overview
Basically, it is a fully offline, privacy focused diary app for Windows. I could have built it completely with all features and password if I had more time but jackpot's deadline was here.
I am building this for myself because I am using a laptop shared by family members and they are very nosy. 
This diary has basic features right now, all that I personally  need.
I was going to add password protection, polish existing features and add more features in season 2. But season 2 is not happening but I'll still continue building it because I really really need it. 

## NOTE for Reviewers: There is very important information about bugs, missing features and some possible unstability
I am attaching this video. Please watch it for proper demo:
* https://drive.proton.me/urls/K3NRRR22W4#55nImXCZAxMp

## Features (Already written by me)
- Multiple daily notes
- Collapsable left & right panes
- Each journal entry (daily note) can be added to favorites.
- Separate Favorites Section. Notes can directly be opened from there also.
- Delete Note (forgot to show in demo but works by right clicking on the tab)
- The app is responsive
- Formatting Toolbar has horizontal scrolling for less space window
- Open a random entry feature
- Image uploads (includgni drag & drop)
- Audio uploads (doesn't work)
- Multiple formatting features

## Bugs & Missing Stuff
I’m still learning so there are a bugs and instability:

#### in Calendar: 
- When a date is selected, the calendar only strokes the date instead of a solid fill.
- But there is always fill on a date, most likely today's date (I didn't had enough time to test it)
- The date selection color is still classic Windows blue.

#### Settings is not built. It has a coming soon banner.

#### Audio import playback issue:
Audio can be imported via drag & drop or button from toolbar but it cannot be played.
I tried to build an "inline placeholder" player that would pop up, but it was way more complicated than I thought. The reviewer can cut about 30minutes to 1hr if they want to.

## Installation Guide
It is not a verified app so please follow these exact steps to install properly:
#### 1. Download the ZIP: 
Grab the latest release ZIP from the Releases tab.
#### 2. Extract All:
Unzip the folder to somewhere safe on your PC.
#### 3. Install Certificate: 
- Double click the security certificate.
- Click Open
- Click on Install Certificate
- Choose either current user or local machine; it's upto you and click Next.
- Choose "Automatically select the certificate store based on the type of certificate" and click Next.
- Click on Finish
- You should see "The import was successful." otherwise something went wrong and you may try again.
#### 4. Install App
Double click on teh msix file and perform a basic installation. 
#### 5. Enjoy 
Once it finishes, Myary will be in your Start Menu like any other app.

## How much AI was used?
I used AI to help me through this in this way:
#### Guidance
AI was a guide for me in setting up things, installing packages and guided me throgh WinUI3 and .NET.

#### Code 
AI wrote about 5-10% code maximum mainly in debugging complex things, including the audio player that didn't work.

## Coming Soon
I'll finish this app as I imagined even though jackpot is over. I have these things in mind:
#### Security
A PIN/Password lock on the app.
Separate PIN/Password for each note if user wants to add it.
Encrypted export options.
#### Actual Settings
Customization options, password protection features
#### Audio Player that works
#### Imports from other apps.
#### Efficiency 
Due to having limited knowledge and experience, the app is clunky & huge. I'll make it more efficient.
