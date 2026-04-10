# Myary - My Personal Diary 📔

Hey there! Welcome to **Myary**, my first windows application I built for myself to use.

## **NOTE:** There is important information about bugs, missing features & AI usage for reviewers.

## ✨ What is Myary?
Basically, it’s a privacy-first diary app for Windows. No cloud, no tracking, no creepy data syncing. Everything stays right on your computer in a local database. It’s got a pretty "Cream & Dusty Rose" theme and lets you write notes, add photos, and even try (emphasis on *try*) to add audio.

## 🛠 My Building Journey
I’m still pretty new to the whole "building real apps" thing, so this has been a wild ride. I started with a blank screen in WinUI 3 and slowly pieced it together. Learning how to connect a database (SQLite), making a sidebar that actually collapses, and trying to get a calendar to talk to my notes was a lot of trial and error.

There were definitely moments where I felt like I was banging my head against the wall (hello, RichText formatting!), but seeing it actually run as a real Windows app for the first time was a huge win.

## 🐛 Bugs & Missing Stuff (The "Good to Know" List)
Since I’m still learning, there are a few things that aren't quite "pro" yet:
*   **Calendar Quirks:** When you pick a date, the calendar only "strokes" the date (draws an outline) instead of a solid fill. Plus, the selection color is still that classic Windows blue because I haven't figured out how to override the system theme for that yet.
*   **Settings is a Tease:** If you click Settings, you’ll just see a "Coming Soon" banner. I have big plans for it, but for v1.0, it’s just a placeholder.
*   **The Audio Situation:** You can totally drag an audio file into the diary, and it'll show up with a fancy tag. But... you can't actually play it yet. I spent about an hour trying to build this cool "inline placeholder" player that would pop up, but it was way more complicated than I thought. For now, the audio is just sitting there looking pretty.
*   **Formatting:** Underlining works, but sometimes it doesn't like to turn off unless you click it just right.

## 🚀 Installation Guide
Since this is a sideloaded app, follow these steps to get it running:
1.  **Download the ZIP:** Grab the latest release ZIP from the Releases tab.
2.  **Extract All:** Unzip the folder to somewhere safe on your PC.
3.  **Run the Installer:** Right-click the file named `Install.ps1` and select **Run with PowerShell**.
4.  **Follow Prompts:** If it asks for permission to install a certificate, say "Yes." This is just to tell Windows you trust this app!
5.  **Enjoy:** Once it finishes, Myary will be in your Start Menu like any other app.

## 🤖 How much AI did I use?
I used an AI assistant (Antigravity) to help me through this! Here’s the breakdown:
*   **The Blueprint:** The AI guided me on the whole tech stack (WinUI 3 + .NET 8), told me which NuGet packages to install (`sqlite-net-pcl`, `CommunityToolkit.Mvvm`), and helped me structure the folders so I didn't make a mess.
*   **The Code:** I wrote the vast majority of the logic and UI myself. The AI helped me with some of the trickier functions and debugging errors—I’d say it wrote less than 10% of the actual code in the end.
*   **This README:** Okay, I'll admit it—the AI wrote this README for me based on my notes!

## 🔮 Coming Soon
I'm not done yet! Here’s what I’m planning for future updates:
*   **Security:** A global PIN/Password lock so only you can read your thoughts.
*   **Actual Settings:** Real customization for themes and account-less preferences.
*   **Audio Fixes:** Making those audio tags actually play music/voice notes!
*   **Import/Export:** A way to backup your entire diary into a single file.
* 
Thanks for checking out Myary! It’s my v1.0 baby, and I’m proud of how far it’s come. 🚀
