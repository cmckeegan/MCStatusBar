//
// MCStatusBar.cs
//
// Author:
//       Charlie McKeegan
//
// Copyright (c) 2013 Charlie McKeegan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
// Based on KGStatusBar.m
//
//  Created by Kevin Gibbon on 2/27/13.
//  Copyright 2013 Kevin Gibbon. All rights reserved.
//  @kevingibbon
//

using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace MagicClaw {
    public class MCStatusBar: UIView {
        private static MCStatusBar sharedView;
        private static MCStatusBar SharedView {
            get {
                return sharedView = sharedView ?? new MCStatusBar(UIScreen.MainScreen.Bounds);
            }
        }

        private MCStatusBar(RectangleF frame): base(frame) {
        }

        private UIWindow OverlayWindow { get; set;}
        private UIView TopBar { get; set; }
        private UILabel MessageLabel { get; set; }
        
        //        + (void)showSuccessWithStatus:(NSString*)status
        //        {
        //            [KGStatusBar showWithStatus:status];
        //            [KGStatusBar performSelector:@selector(dismiss) withObject:self afterDelay:2.0 ];
        //        }
        public static void ShowSuccessWithStatus(string status) {
            // ShowWithStatus()
        }

//        
//        + (void)showWithStatus:(NSString*)status {
//            [[KGStatusBar sharedView] showWithStatus:status barColor:[UIColor blackColor] textColor:[UIColor colorWithRed:191.0/255.0 green:191.0/255.0 blue:191.0/255.0 alpha:1.0]];
//        }
        public static void ShowWithStatus(String status) {
            SharedView.Show(status, UIColor.Black, UIColor.FromRGBA(191 / 255, 191 / 255, 191 / 255, 1f));
        }
//        
//        + (void)showErrorWithStatus:(NSString*)status {
//            [[KGStatusBar sharedView] showWithStatus:status barColor:[UIColor colorWithRed:97.0/255.0 green:4.0/255.0 blue:4.0/255.0 alpha:1.0] textColor:[UIColor colorWithRed:255.0/255.0 green:255.0/255.0 blue:255.0/255.0 alpha:1.0]];
//            [KGStatusBar performSelector:@selector(dismiss) withObject:self afterDelay:2.0 ];
//        }
//        
//        + (void)dismiss {
//            [[KGStatusBar sharedView] dismiss];
//        }
//        
//        - (id)initWithFrame:(CGRect)frame {
//            
//            if ((self = [super initWithFrame:frame])) {
//                self.userInteractionEnabled = NO;
//                self.backgroundColor = [UIColor clearColor];
//                self.alpha = 0;
//                self.autoresizingMask = UIViewAutoresizingFlexibleWidth | UIViewAutoresizingFlexibleHeight;
//            }
//            return self;
//        }
//        
//        - (void)showWithStatus:(NSString *)status barColor:(UIColor*)barColor textColor:(UIColor*)textColor{
//            if(!self.superview)
//                [self.overlayWindow addSubview:self];
//            [self.overlayWindow setHidden:NO];
//            [self.topBar setHidden:NO];
//            self.topBar.backgroundColor = barColor;
//            NSString *labelText = status;
//            CGRect labelRect = CGRectZero;
//            CGFloat stringWidth = 0;
//            CGFloat stringHeight = 0;
//            if(labelText) {
//                CGSize stringSize = [labelText sizeWithFont:self.stringLabel.font constrainedToSize:CGSizeMake(self.topBar.frame.size.width, self.topBar.frame.size.height)];
//                stringWidth = stringSize.width;
//                stringHeight = stringSize.height;
//                
//                labelRect = CGRectMake((self.topBar.frame.size.width / 2) - (stringWidth / 2), 0, stringWidth, stringHeight);
//            }
//            self.stringLabel.frame = labelRect;
//            self.stringLabel.alpha = 0.0;
//            self.stringLabel.hidden = NO;
//            self.stringLabel.text = labelText;
//            self.stringLabel.textColor = textColor;
//            [UIView animateWithDuration:0.4 animations:^{
//                self.stringLabel.alpha = 1.0;
//             }];
//            [self setNeedsDisplay];
//        }
        private void Show(string status, UIColor barColor, UIColor textColor) {
            if (Superview == null)
                OverlayWindow.AddSubview(this);
            OverlayWindow.Hidden = false;
            TopBar.Hidden = false;
            TopBar.BackgroundColor = barColor;

            MessageLabel.Alpha = 0f;
            MessageLabel.Text = status;
            MessageLabel.TextColor = textColor;
            MessageLabel.Hidden = false;
            UIView.Animate(0.4, () => {
                MessageLabel.Alpha = 1f;
            });
            this.SetNeedsDisplay();
        }
//        
//        - (void) dismiss
//        {
//            [UIView animateWithDuration:0.4 animations:^{
//                self.stringLabel.alpha = 0.0;
//             } completion:^(BOOL finished) {
//                [topBar removeFromSuperview];
//                topBar = nil;
//                
//                [overlayWindow removeFromSuperview];
//                overlayWindow = nil;
//             }];
//        }
//        
//        - (UIWindow *)overlayWindow {
//            if(!overlayWindow) {
//                overlayWindow = [[UIWindow alloc] initWithFrame:[UIScreen mainScreen].bounds];
//                overlayWindow.autoresizingMask = UIViewAutoresizingFlexibleWidth | UIViewAutoresizingFlexibleHeight;
//                overlayWindow.backgroundColor = [UIColor clearColor];
//                overlayWindow.userInteractionEnabled = NO;
//                overlayWindow.windowLevel = UIWindowLevelStatusBar;
//            }
//            return overlayWindow;
//        }
//        
//        - (UIView *)topBar {
//            if(!topBar) {
//                topBar = [[UIView alloc] initWithFrame:CGRectMake(0, 0, overlayWindow.frame.size.width, 20.0)];
//                [overlayWindow addSubview:topBar];
//            }
//            return topBar;
//        }
//        
//        - (UILabel *)stringLabel {
//            if (stringLabel == nil) {
//                stringLabel = [[UILabel alloc] initWithFrame:CGRectZero];
//                stringLabel.textColor = [UIColor colorWithRed:191.0/255.0 green:191.0/255.0 blue:191.0/255.0 alpha:1.0];
//                stringLabel.backgroundColor = [UIColor clearColor];
//                stringLabel.adjustsFontSizeToFitWidth = YES;
//                #if __IPHONE_OS_VERSION_MIN_REQUIRED < 60000
//                stringLabel.textAlignment = UITextAlignmentCenter;
//                #else
//                stringLabel.textAlignment = NSTextAlignmentCenter;
//                #endif
//                stringLabel.baselineAdjustment = UIBaselineAdjustmentAlignCenters;
//                stringLabel.font = [UIFont boldSystemFontOfSize:14.0];
//                stringLabel.shadowColor = [UIColor blackColor];
//                stringLabel.shadowOffset = CGSizeMake(0, -1);
//                stringLabel.numberOfLines = 0;
//            }
//            
//            if(!stringLabel.superview)
//                [self.topBar addSubview:stringLabel];
//            
//            return stringLabel;
//        }
//        
//        @end
//
    }
}

