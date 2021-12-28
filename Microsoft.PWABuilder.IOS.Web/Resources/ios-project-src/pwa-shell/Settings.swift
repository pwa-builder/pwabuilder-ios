import WebKit

struct Cookie {
    var name: String
    var value: String
}

let gcmMessageIDKey = "00000000000" //pwashellz: update this with actual ID if using Firebase 

// URL for first launch
let rootUrl = URL(string: "{{PWABuilder.iOS.url}}")!

// allowed origin is for what we are sticking to pwa domain
// This should also appear in Info.plist
let allowedOrigin = "{{PWABuilder.iOS.urlHost}}"

// auth origins will open in modal and show toolbar for back into the main origin.
// These should also appear in Info.plist
let authOrigins: [String] = ["{{PWABuilder.iOS.permittedHosts}}"]

let platformCookie = Cookie(name: "app-platform", value: "iOS App Store")

let displayMode = "standalone" //standalone / fullscreen

//let statusBarColor = "#FFFFFF"
//let statusBarStyle = UIStatusBarStyle.lightContent
