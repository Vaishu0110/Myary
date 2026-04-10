# Myary - My Personal Diary 📔

Hey there! Welcome to **Myary**, my first windows application I built for myself to use.

## NOTE: There is important information about bugs, missing features & AI usage for reviewers.
## NOTE 2 (FOR REVEIWERS): App is unstable and some features might be broken on different computers. I have attached a video below to showcase full functionality of the app.
* https://drive.proton.me/urls/K3NRRR22W4#55nImXCZAxMp

## ✨ What is Myary?
Basically, it’s a privacy-first diary app for Windows. No cloud, no tracking, no creepy data syncing. Everything stays right on your computer in a local database. It’s got a pretty "Cream & Dusty Rose" theme and lets you write notes, add photos, and even try (emphasis on *try*) to add audio.

## 🛠 My Building Journey
I’m still pretty new to the whole "building real apps" thing, so this has been a wild ride. I started with a blank screen in WinUI 3 and slowly pieced it together. Learning how to connect a database (SQLite), making a sidebar that actually collapses, and trying to get a calendar to talk to my notes was a lot of trial and error.

There were definitely moments where I felt like I was banging my head against the wall (hello, RichText formatting!), but seeing it actually run as a real Windows app for the first time was a huge win.

And especially since I could do so much in so little time, mainly by not sleeping for entire 24 hours so that I could finish it for Jackpot ysws by HackClub.

## Features
- Multiple daily note marked to dates
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

## 🐛 Bugs & Missing Stuff (The "Good to Know" List)
Since I’m still learning, there are a few things that aren't quite "pro" yet:
#### Calendar Quirks: 
- When you pick a date, the calendar only "strokes" the date (draws an outline) instead of a solid fill.
- But it does add a proper selected-like fill on one of the dates, typically today's date (I didn't have enough time to test it)
- Plus, the selection color is still that classic Windows blue because I haven't figured out how to override the system theme for that yet.

#### Settings is a Tease: 
If you click Settings, you’ll just see a "Coming Soon" banner. 
I have big plans for it, but for v1.0, it’s just a placeholder.

#### The Audio Situation:
You can totally drag an audio file into the diary, and it'll show up with a fancy tag. 
But... you can't actually play it yet. 
I spent about an hour trying to build this cool "inline placeholder" player that would pop up, but it was way more complicated than I thought. 
For now, the audio is just sitting there looking pretty.

## 🚀 Installation Guide
Since this is a sideloaded app, follow these exact steps to get it running:
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

## 🤖 How much AI did I use?
I used AI to help me through this! Here’s the breakdown:
*   **The Blueprint:** The AI **guided** me on the whole tech stack (WinUI 3 + .NET 8), told me which NuGet packages to install (`sqlite-net-pcl`, `CommunityToolkit.Mvvm`), and helped me structure the folders so I didn't make a mess.
*   **The Code:** I wrote the vast majority of the logic and UI myself. The AI helped me with some of the trickier functions and debugging errors—I’d say it wrote **less than 10% of the actual code** in the end.
*   **This README:** Okay, I'll admit it—the AI wrote this README for me based on my notes!

## 🔮 Coming Soon
I'm not done yet! Here’s what I’m planning for future updates:
*   **Security:** A global PIN/Password lock so only you can read your thoughts.
*   **Actual Settings:** Real customization for themes and account-less preferences.
*   **Audio Fixes:** Making those audio tags actually play music/voice notes!
*   **Import/Export:** A way to backup your entire diary into a single file.
*   **Efficiency:** Due to my limited knowledge and experience, the app is clunky & huge. I'll make it more efficient.

Thanks for checking out Myary! It’s my v1.0 baby, and I’m proud of how far it’s come. 🚀
