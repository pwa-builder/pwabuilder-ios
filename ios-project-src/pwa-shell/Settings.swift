//
//  Settings.swift
//  pwa-shell
//
//  Created by Gleb Khmyznikov on 11/23/19.
//  
//

import WebKit

struct Cookie {
    var name: String
    var value: String
}

let gcmMessageIDKey = "00000000000" //pwashellz: update this with actual ID if using Firebase 

// URL for first launch
let rootUrl = URL(string: "https://messianicchords.com/?pwashellz")!

// allowed origin is for what we are sticking to pwa domain
// This should also appear in Info.plist
let allowedOrigin = "messianicchords.com"

// auth origins will open in modal and show toolbar for back into the main origin.
// These should also appear in Info.plist
let authOrigins = ["login.microsoftonline.com"]

let platformCookie = Cookie(name: "app-platform", value: "iOS App Store")


//let statusBarColor = "#FFFFFF"
//let statusBarStyle = UIStatusBarStyle.lightContent
