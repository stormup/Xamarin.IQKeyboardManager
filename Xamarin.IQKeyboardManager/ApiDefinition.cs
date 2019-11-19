using System;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Xamarin
{
    [BaseType(typeof(UIBarButtonItem))]
    interface IQBarButtonItem
    {
        /**
         Boolean to know if it's a system item or custom item
         */
        //@property(nonatomic, readonly) BOOL isSystemItem;
        [Export("isSystemItem")]
        bool IsSystemItem { get; }


        /**
         Additional target & action to do get callback action. Note that setting custom target & selector doesn't affect native functionality, this is just an additional target to get a callback.
 
         @param target Target object.
         @param action Target Selector.
         */
        //-(void) setTarget:(nullable id) target action:(nullable SEL) action;

        [Export("setTarget:action:")]
        void SetTarget([NullAllowed] NSObject target, [NullAllowed] Selector action);

        /**
         Customized Invocation to be called when button is pressed. invocation is internally created using setTarget:action: method.
         */
        //@property(nullable, strong, nonatomic) NSInvocation* invocation;
        [NullAllowed, Export("invocation", ArgumentSemantic.Strong)]
        NSInvocation Invocation { get; set; }
    }


    // @interface IQKeyboardManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface IQKeyboardManager
    {
        ///--------------------------
        /// @name UIKeyboard handling
        ///--------------------------

        /**
         Returns the default singleton instance. You are not allowed to create your own instances of this class.
         */
        //+ (nonnull instancetype)sharedManager;
        [Static]
        [Export("sharedManager")]
        IQKeyboardManager SharedManager { get; }

        /**
         Enable/disable managing distance between keyboard and textField. Default is YES(Enabled when class loads in `+(void)load` method).
         */
        //@property(nonatomic, assign, getter = isEnabled) BOOL enable;
        [Export("enable")]
        bool Enable { [Bind("isEnabled")] get; set; }

        /**
         To set keyboard distance from textField. can't be less than zero. Default is 10.0.
         */
        //@property(nonatomic, assign) CGFloat keyboardDistanceFromTextField;
        [Export("keyboardDistanceFromTextField")]
        nfloat KeyboardDistanceFromTextField { get; set; }

        /**
         Refreshes textField/textView position if any external changes is explicitly made by user.
         */
        //- (void) reloadLayoutIfNeeded;
        [Export("reloadLayoutIfNeeded")]
        void ReloadLayoutIfNeeded();

        /** 
         Boolean to know if keyboard is showing.
         */
        //@property(nonatomic, assign, readonly, getter = isKeyboardShowing) BOOL keyboardShowing;
        [Export("keyboardShowing")]
        bool IsKeyboardShowing { [Bind("isKeyboardShowing")] get; }

        /**
         moved distance to the top used to maintain distance between keyboard and textField. Most of the time this will be a positive value.
         */
        //@property(nonatomic, assign, readonly) CGFloat movedDistance;
        [Export("movedDistance")]
        nfloat MovedDistance { get; }

        /**
         Will be called then movedDistance will be changed.
         */
        //@property(nullable, nonatomic, copy) void (^movedDistanceChanged)(CGFloat movedDistance);
        //TODO: Not working, it may be the pointer, and how it handles it
        //[Export("movedDistanceChanged", ArgumentSemantic.Copy)]
        //void MovedDistanceChanged(nfloat movedDistance);

        ///-------------------------
        /// @name IQToolbar handling
        ///-------------------------

        /**
         Automatic add IQToolbar functionality. Default is YES.
         */
        //@property(nonatomic, assign, getter = isEnableAutoToolbar) BOOL enableAutoToolbar;
        [Export("enableAutoToolbar")]
        bool EnableAutoToolbar { [Bind("isEnableAutoToolbar")] get; set; }


        /**
         IQAutoToolbarBySubviews:   Creates Toolbar according to subview's hirarchy of Textfield's in view.
         IQAutoToolbarByTag:        Creates Toolbar according to tag property of TextField's.
         IQAutoToolbarByPosition:   Creates Toolbar according to the y,x position of textField in it's superview coordinate.

         Default is IQAutoToolbarBySubviews.
        */
        //@property(nonatomic, assign) IQAutoToolbarManageBehaviour toolbarManageBehaviour;
        [Export("toolbarManageBehaviour", ArgumentSemantic.Assign)]
        IQAutoToolbarManageBehaviour ToolbarManageBehaviour { get; set; }


        /**
         If YES, then uses textField's tintColor property for IQToolbar, otherwise tint color is nil. Default is NO.
         */
        //@property(nonatomic, assign) BOOL shouldToolbarUsesTextFieldTintColor;
        [Export("shouldToolbarUsesTextFieldTintColor")]
        bool ShouldToolbarUsesTextFieldTintColor { get; set; }

        /**
         This is used for toolbar.tintColor when textfield.keyboardAppearance is UIKeyboardAppearanceDefault. If shouldToolbarUsesTextFieldTintColor is YES then this property is ignored. Default is nil.
         */
        //@property(nullable, nonatomic, strong) UIColor* toolbarTintColor;
        [NullAllowed, Export("toolbarTintColor", ArgumentSemantic.Strong)]
        UIColor ToolbarTintColor { get; set; }

        /**
         This is used for toolbar.barTintColor. Default is nil.
         */
        //@property(nullable, nonatomic, strong) UIColor* toolbarBarTintColor;
        [NullAllowed, Export("toolbarBarTintColor", ArgumentSemantic.Strong)]
        UIColor ToolbarBarTintColor { get; set; }

        /**
         IQPreviousNextDisplayModeDefault:      Show NextPrevious when there are more than 1 textField otherwise hide.
         IQPreviousNextDisplayModeAlwaysHide:   Do not show NextPrevious buttons in any case.
         IQPreviousNextDisplayModeAlwaysShow:   Always show nextPrevious buttons, if there are more than 1 textField then both buttons will be visible but will be shown as disabled.
         */
        //@property(nonatomic, assign) IQPreviousNextDisplayMode previousNextDisplayMode;
        [Export("previousNextDisplayMode", ArgumentSemantic.Assign)]
        IQPreviousNextDisplayMode PreviousNextDisplayMode { get; set; }


        /**
         Toolbar previous/next/done button icon, If nothing is provided then check toolbarDoneBarButtonItemText to draw done button.
         */

        //@property(nullable, nonatomic, strong) UIImage* toolbarPreviousBarButtonItemImage;
        [NullAllowed, Export("toolbarPreviousBarButtonItemImage", ArgumentSemantic.Strong)]
        UIImage ToolbarPreviousBarButtonItemImage { get; set; }

        //@property(nullable, nonatomic, strong) UIImage* toolbarNextBarButtonItemImage;
        [NullAllowed, Export("toolbarNextBarButtonItemImage", ArgumentSemantic.Strong)]
        UIImage ToolbarNextBarButtonItemImage { get; set; }

        //@property(nullable, nonatomic, strong) UIImage* toolbarDoneBarButtonItemImage;
        [NullAllowed, Export("toolbarDoneBarButtonItemImage", ArgumentSemantic.Strong)]
        UIImage ToolbarDoneBarButtonItemImage { get; set; }


        /**
         Toolbar previous/next/done button text, If nothing is provided then system default 'UIBarButtonSystemItemDone' will be used.
         */
        //@property(nullable, nonatomic, strong) NSString* toolbarPreviousBarButtonItemText;
        [NullAllowed, Export("toolbarPreviousBarButtonItemText", ArgumentSemantic.Strong)]
        string ToolbarPreviousBarButtonItemText { get; set; }

        //@property(nullable, nonatomic, strong) NSString* toolbarPreviousBarButtonItemAccessibilityLabel;
        [NullAllowed, Export("toolbarPreviousBarButtonItemAccessibilityLabel", ArgumentSemantic.Strong)]
        string ToolbarPreviousBarButtonItemAccessibilityLabel { get; set; }

        //@property(nullable, nonatomic, strong) NSString* toolbarNextBarButtonItemText;
        [NullAllowed, Export("toolbarNextBarButtonItemText", ArgumentSemantic.Strong)]
        string ToolbarNextBarButtonItemText { get; set; }

        //@property(nullable, nonatomic, strong) NSString* toolbarNextBarButtonItemAccessibilityLabel;
        [NullAllowed, Export("toolbarNextBarButtonItemAccessibilityLabel", ArgumentSemantic.Strong)]
        string ToolbarNextBarButtonItemAccessibilityLabel { get; set; }

        //@property(nullable, nonatomic, strong) NSString* toolbarDoneBarButtonItemText;
        [NullAllowed, Export("toolbarDoneBarButtonItemText", ArgumentSemantic.Strong)]
        string ToolbarDoneBarButtonItemText { get; set; }

        //@property(nullable, nonatomic, strong) NSString* toolbarDoneBarButtonItemAccessibilityLabel;
        [NullAllowed, Export("toolbarDoneBarButtonItemAccessibilityLabel", ArgumentSemantic.Strong)]
        string ToolbarDoneBarButtonItemAccessibilityLabel { get; set; }

        /**
         If YES, then it add the textField's placeholder text on IQToolbar. Default is YES.
         */
        //@property(nonatomic, assign) BOOL shouldShowToolbarPlaceholder;
        [Export("shouldShowToolbarPlaceholder")]
        bool ShouldShowToolbarPlaceholder { get; set; }

        /**
         Placeholder Font. Default is nil.
        */
        //@property(nullable, nonatomic, strong) UIFont* placeholderFont;
        [NullAllowed, Export("placeholderFont", ArgumentSemantic.Strong)]
        UIFont PlaceholderFont { get; set; }

        /**
         Placeholder Color. Default is nil. Which means lightGray
         */
        //@property(nullable, nonatomic, strong) UIColor* placeholderColor;
        [NullAllowed, Export("placeholderColor", ArgumentSemantic.Strong)]
        UIColor PlaceholderColor { get; set; }

        /**
         Placeholder Button Color when it's treated as button. Default is nil
         */
        //@property(nullable, nonatomic, strong) UIColor* placeholderButtonColor;
        [NullAllowed, Export("placeholderButtonColor", ArgumentSemantic.Strong)]
        UIColor PlaceholderButtonColor { get; set; }

        /**
            Reload all toolbar buttons on the fly.
        */
        //- (void) reloadInputViews;
        [Export("reloadInputViews")]
        void ReloadInputViews();

        ///---------------------------------------
        /// @name UIKeyboard appearance overriding
        ///---------------------------------------

        /**
         Override the keyboardAppearance for all textField/textView. Default is NO.
         */
        //@property(nonatomic, assign) BOOL overrideKeyboardAppearance;
        [Export("overrideKeyboardAppearance")]
        bool OverrideKeyboardAppearance { get; set; }

        /**
         If overrideKeyboardAppearance is YES, then all the textField keyboardAppearance is set using this property.
         */
        //@property(nonatomic, assign) UIKeyboardAppearance keyboardAppearance;
        [Export("keyboardAppearance", ArgumentSemantic.Assign)]
        UIKeyboardAppearance KeyboardAppearance { get; set; }


        ///-----------------------------------------------------------
        /// @name UITextField/UITextView Next/Previous/Resign handling
        ///-----------------------------------------------------------

        /**
         Resigns Keyboard on touching outside of UITextField/View. Default is NO.
         */
        // @property(nonatomic, assign) BOOL shouldResignOnTouchOutside;
        [Export("shouldResignOnTouchOutside")]
        bool ShouldResignOnTouchOutside { get; set; }

        /** TapGesture to resign keyboard on view's touch. It's a readonly property and exposed only for adding/removing dependencies if your added gesture does have collision with this one */
        //@property(nonnull, nonatomic, strong, readonly) UITapGestureRecognizer* resignFirstResponderGesture;
        [Export("resignFirstResponderGesture", ArgumentSemantic.Strong)]
        UITapGestureRecognizer ResignFirstResponderGesture { get; }

        /**
         Resigns currently first responder field.
         */
        //-(BOOL)resignFirstResponder;
        [Export("resignFirstResponder")]
        bool ResignFirstResponder();

        /**
         Returns YES if can navigate to previous responder textField/textView, otherwise NO.
         */
        //@property(nonatomic, readonly) BOOL canGoPrevious;
        [Export("canGoPrevious")]
        bool CanGoPrevious { get; }

        /**
         Returns YES if can navigate to next responder textField/textView, otherwise NO.
         */
        //@property(nonatomic, readonly) BOOL canGoNext;
        [Export("canGoNext")]
        bool CanGoNext { get; }

        /**
         Navigate to previous responder textField/textView.
         */
        //- (BOOL) goPrevious;
        [Export("goPrevious")]
        bool GoPrevious();

        /**
         Navigate to next responder textField/textView.
         */
        //- (BOOL) goNext;
        [Export("goNext")]
        bool GoNext();

        ///-----------------------
        /// @name UISound handling
        ///-----------------------

        /**
         If YES, then it plays inputClick sound on next/previous/done click. Default is YES.
         */
        //@property(nonatomic, assign) BOOL shouldPlayInputClicks;
        [Export("shouldPlayInputClicks")]
        bool ShouldPlayInputClicks { get; set; }

        ///---------------------------
        /// @name UIAnimation handling
        ///---------------------------

        /**
         If YES, then calls 'setNeedsLayout' and 'layoutIfNeeded' on any frame update of to viewController's view.
         */
        //@property(nonatomic, assign) BOOL layoutIfNeededOnUpdate;
        [Export("layoutIfNeededOnUpdate")]
        bool LayoutIfNeededOnUpdate { get; set; }


        ///---------------------------------------------
        /// @name Class Level enabling/disabling methods
        ///---------------------------------------------
        ///

        /**
         Disable distance handling within the scope of disabled distance handling viewControllers classes. Within this scope, 'enabled' property is ignored. Class should be kind of UIViewController. Default is [UITableViewController, UIAlertController, _UIAlertControllerTextFieldViewController].
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* disabledDistanceHandlingClasses;
        [Export("disabledDistanceHandlingClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> DisabledDistanceHandlingClasses { get; }

        /**
         Enable distance handling within the scope of enabled distance handling viewControllers classes. Within this scope, 'enabled' property is ignored. Class should be kind of UIViewController. Default is [].
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* enabledDistanceHandlingClasses;
        [Export("enabledDistanceHandlingClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> EnabledDistanceHandlingClasses { get; }

        /**
         Disable automatic toolbar creation within the scope of disabled toolbar viewControllers classes. Within this scope, 'enableAutoToolbar' property is ignored. Class should be kind of UIViewController. Default is [UIAlertController, _UIAlertControllerTextFieldViewController].
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* disabledToolbarClasses;
        [Export("disabledToolbarClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> DisabledToolbarClasses { get; }

        /**
         Enable automatic toolbar creation within the scope of enabled toolbar viewControllers classes. Within this scope, 'enableAutoToolbar' property is ignored. Class should be kind of UIViewController. Default is [].
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* enabledToolbarClasses;
        [Export("enabledToolbarClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> EnabledToolbarClasses { get; }

        /**
         Allowed subclasses of UIView to add all inner textField, this will allow to navigate between textField contains in different superview. Class should be kind of UIView. Default is [UITableView, UICollectionView, IQPreviousNextView].
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* toolbarPreviousNextAllowedClasses;
        [Export("toolbarPreviousNextAllowedClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> ToolbarPreviousNextAllowedClasses { get; }

        /**
         Disabled classes to ignore 'shouldResignOnTouchOutside' property, Class should be kind of UIViewController. Default is [UIAlertController, UIAlertControllerTextFieldViewController]
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* disabledTouchResignedClasses;
        [Export("disabledTouchResignedClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> DisabledTouchResignedClasses { get; }

        /**
         Enabled classes to forcefully enable 'shouldResignOnTouchOutsite' property. Class should be kind of UIViewController. Default is [].
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* enabledTouchResignedClasses;
        [Export("enabledTouchResignedClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> EnabledTouchResignedClasses { get; }

        /**
         if shouldResignOnTouchOutside is enabled then you can customise the behaviour to not recognise gesture touches on some specific view subclasses. Class should be kind of UIView. Default is [UIControl, UINavigationBar]
         */
        //@property(nonatomic, strong, nonnull, readonly) NSMutableSet<Class>* touchResignedGestureIgnoreClasses;
        [Export("touchResignedGestureIgnoreClasses", ArgumentSemantic.Strong)]
        NSMutableSet<Class> TouchResignedGestureIgnoreClasses { get; }


        ///-------------------------------------------
        /// @name Third Party Library support
        /// Add TextField/TextView Notifications customised NSNotifications. For example while using YYTextView https://github.com/ibireme/YYText
        ///-------------------------------------------

        /**
         Add/Remove customised Notification for third party customised TextField/TextView. Please be aware that the NSNotification object must be idential to UITextField/UITextView NSNotification objects and customised TextField/TextView support must be idential to UITextField/UITextView.
         @param didBeginEditingNotificationName This should be identical to UITextViewTextDidBeginEditingNotification
         @param didEndEditingNotificationName This should be identical to UITextViewTextDidEndEditingNotification
         */

        //-(void) registerTextFieldViewClass:(nonnull Class) aClass
        //  didBeginEditingNotificationName:(nonnull NSString *)didBeginEditingNotificationName
        //    didEndEditingNotificationName:(nonnull NSString *)didEndEditingNotificationName;
        [Export("registerTextFieldViewClass:didBeginEditingNotificationName:didEndEditingNotificationName:")]
        void RegisterTextFieldViewClass(Class aClass, string didBeginEditingNotificationName, string didEndEditingNotificationName);

        //-(void) unregisterTextFieldViewClass:(nonnull Class) aClass
        //    didBeginEditingNotificationName:(nonnull NSString *)didBeginEditingNotificationName
        //      didEndEditingNotificationName:(nonnull NSString *)didEndEditingNotificationName;
        [Export("unregisterTextFieldViewClass:didBeginEditingNotificationName:didEndEditingNotificationName:")]
        void UnregisterTextFieldViewClass(Class aClass, string didBeginEditingNotificationName, string didEndEditingNotificationName);

        ///----------------------------------------
        /// @name Debugging & Developer options
        ///----------------------------------------

        //@property(nonatomic, assign) BOOL enableDebugging;
        [Export("enableDebugging")]
        bool EnableDebugging { get; set; }


        /**
         @warning Use these methods to completely enable/disable notifications registered by library internally. Please keep in mind that library is totally dependent on NSNotification of UITextField, UITextField, Keyboard etc. If you do unregisterAllNotifications then library will not work at all. You should only use below methods if you want to completedly disable all library functions. You should use below methods at your own risk.
         */
        //-(void)registerAllNotifications;
        [Export("registerAllNotifications")]
        void RegisterAllNotifications();

        //-(void)unregisterAllNotifications;
        [Export("unregisterAllNotifications")]
        void UnregisterAllNotifications();

        ///----------------------------------------
        /// @name Must not be used for subclassing.
        ///----------------------------------------

        /**
         Unavailable. Please use sharedManager method
         */
        //-(nonnull instancetype) init NS_UNAVAILABLE;

        /**
         Unavailable. Please use sharedManager method
         */
        //+ (nonnull instancetype) new NS_UNAVAILABLE;
    }



    [BaseType(typeof(NSObject))]
    interface IQKeyboardReturnKeyHandler
    {
        ///----------------------
        /// @name Initializations
        ///----------------------

        /**
         Add all the textFields available in UIViewController's view.
         */
        //-(nonnull instancetype) initWithViewController:(nullable UIViewController*)controller NS_DESIGNATED_INITIALIZER;
        [Export("initWithViewController:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] UIViewController controller);

        ///**
        // Unavailable. Please use initWithViewController: or init method
        // */
        //-(nonnull instancetype) initWithCoder:(nullable NSCoder *)aDecoder NS_UNAVAILABLE;

        ///---------------
        /// @name Settings
        ///---------------

        /**
         Delegate of textField/textView.
         */
        //@property(nullable, nonatomic, weak) id<UITextFieldDelegate, UITextViewDelegate> delegate;
        [Wrap("WeakDelegate")]
        [NullAllowed]
        NSObject Delegate { get; set; }

        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        /**
         Set the last textfield return key type. Default is UIReturnKeyDefault.
         */
        //@property(nonatomic, assign) UIReturnKeyType lastTextFieldReturnKeyType;
        [Export("lastTextFieldReturnKeyType", ArgumentSemantic.Assign)]
        UIReturnKeyType LastTextFieldReturnKeyType { get; set; }

        ///----------------------------------------------
        /// @name Registering/Unregistering textFieldView
        ///----------------------------------------------

        /**
         Should pass UITextField/UITextView instance. Assign textFieldView delegate to self, change it's returnKeyType.

         @param textFieldView UITextField/UITextView object to register.
         */
        //-(void) addTextFieldView:(nonnull UIView*)textFieldView;
        [Export("addTextFieldView:")]
        void AddTextFieldView(UIView textFieldView);

        /**
         Should pass UITextField/UITextView instance. Restore it's textFieldView delegate and it's returnKeyType.

         @param textFieldView UITextField/UITextView object to unregister.
         */
        //-(void) removeTextFieldView:(nonnull UIView*)textFieldView;
        [Export("removeTextFieldView:")]
        void RemoveTextFieldView(UIView textFieldView);

        /**
         Add all the UITextField/UITextView responderView's.

         @param view object to register all it's responder subviews.
         */
        //-(void) addResponderFromView:(nonnull UIView*)view;
        [Export("addResponderFromView:")]
        void AddResponderFromView(UIView view);

        /**
         Remove all the UITextField/UITextView responderView's.

         @param view object to unregister all it's responder subviews.
         */
        //-(void) removeResponderFromView:(nonnull UIView*)view;
        [Export("removeResponderFromView:")]
        void RemoveResponderFromView(UIView view);
    }

    [BaseType(typeof(UIView))]
    interface IQPreviousNextView
    {

    }

    /**
     UITextView with placeholder support
     */
    [BaseType(typeof(UITextView))]
    interface IQTextView
    {
        /**
         Set textView's placeholder text. Default is nil.
         */
        //@property(nullable, nonatomic, copy) IBInspectable NSString    *placeholder;
        [NullAllowed, Export("placeholder", ArgumentSemantic.Copy)]
        string Placeholder { get; set; }

        /**
        Set textView's placeholder attributed text. Default is nil.
        */
        //@property(nullable, nonatomic, copy) IBInspectable NSAttributedString    *attributedPlaceholder;
        [NullAllowed, Export("attributedPlaceholder", ArgumentSemantic.Copy)]
        NSAttributedString AttributedPlaceholder { get; set; }

        /**
         To set textView's placeholder text color. Default is nil.
         */
        //@property(nullable, nonatomic, copy) IBInspectable UIColor    *placeholderTextColor;
        [NullAllowed, Export("placeholderTextColor", ArgumentSemantic.Copy)]
        UIColor PlaceholderTextColor { get; set; }
    }

    /**
     BarButtonItem with title text.
     */
    [BaseType(typeof(IQBarButtonItem))]
    [DisableDefaultCtor]
    interface IQTitleBarButtonItem
    {
        /**
         Font to be used in bar button. Default is (system font 12.0 bold).
         */
        //@property(nullable, nonatomic, strong) UIFont* titleFont;
        [NullAllowed, Export("titleFont", ArgumentSemantic.Strong)]
        UIFont TitleFont { get; set; }

        /**
         titleColor to be used for displaying button text when displaying title (disabled state).
         */
        //@property(nullable, nonatomic, strong) UIColor* titleColor;
        [NullAllowed, Export("titleColor", ArgumentSemantic.Strong)]
        UIColor TitleColor { get; set; }

        /**
         selectableTitleColor to be used for displaying button text when button is enabled.
         */
        //@property(nullable, nonatomic, strong) UIColor* selectableTitleColor;
        [NullAllowed, Export("selectableTitleColor", ArgumentSemantic.Strong)]
        UIColor selectableTitleColor { get; set; }

        /**
         Initialize with frame and title.

         @param title Title of barButtonItem.
         */
        //-(nonnull instancetype) initWithTitle:(nullable NSString *)title NS_DESIGNATED_INITIALIZER;
        [Export("initWithTitle:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string title);

        /**
         Unavailable. Please use initWithFrame:title: method
         */
        //-(nonnull instancetype) init NS_UNAVAILABLE;

        /**
         Unavailable. Please use initWithFrame:title: method
         */
        //-(nonnull instancetype) initWithCoder:(nullable NSCoder *)aDecoder NS_UNAVAILABLE;

        /**
         Unavailable. Please use initWithFrame:title: method
         */
        //+ (nonnull instancetype) new NS_UNAVAILABLE;
    }

    /**
     IQToolbar for IQKeyboardManager.
     */
    [BaseType(typeof(UIToolbar))]
    interface IQToolbar
    {
        /**
         Previous bar button of toolbar.
         */
        //@property(nonnull, nonatomic, strong) IQBarButtonItem* previousBarButton;
        [Export("previousBarButton", ArgumentSemantic.Strong)]
        IQBarButtonItem PreviousBarButton { get; set; }

        /**
         Next bar button of toolbar.
         */
        //@property(nonnull, nonatomic, strong) IQBarButtonItem* nextBarButton;
        [Export("nextBarButton", ArgumentSemantic.Strong)]
        IQBarButtonItem NextBarButton { get; set; }

        /**
         Title bar button of toolbar.
         */
        //@property(nonnull, nonatomic, strong, readonly) IQTitleBarButtonItem* titleBarButton;
        [Export("titleBarButton", ArgumentSemantic.Strong)]
        IQTitleBarButtonItem TitleBarButton { get; }

        /**
         Done bar button of toolbar.
         */
        //@property(nonnull, nonatomic, strong) IQBarButtonItem* doneBarButton;
        [Export("doneBarButton", ArgumentSemantic.Strong)]
        IQBarButtonItem DoneBarButton { get; set; }

        /**
         Fixed space bar button of toolbar.
         */
        //@property(nonnull, nonatomic, strong) IQBarButtonItem* fixedSpaceBarButton;
        [Export("fixedSpaceBarButton", ArgumentSemantic.Strong)]
        IQBarButtonItem FixedSpaceBarButton { get; set; }
    }

    /// <summary>
    /// IQUIScrollView+Additions
    /// </summary>
    [Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_Additions
    {
        /**
         If YES, then scrollview will ignore scrolling (simply not scroll it) for adjusting textfield position. Default is NO.
         */
        //@property(nonatomic, assign) BOOL shouldIgnoreScrollingAdjustment;
        [Export("shouldIgnoreScrollingAdjustment")]
        bool GetShouldIgnoreScrollingAdjustment();

        [Export("shouldIgnoreScrollingAdjustment")]
        void SetShouldIgnoreScrollingAdjustment(bool value);

        /**
        Restore scrollViewContentOffset when resigning from scrollView. Default is NO.
        */
        //@property(nonatomic, assign) BOOL shouldRestoreScrollViewContentOffset;
        [Export("shouldRestoreScrollViewContentOffset")]
        bool GetShouldRestoreScrollViewContentOffset();

        [Export("shouldRestoreScrollViewContentOffset")]
        void SetShouldRestoreScrollViewContentOffset(bool value);
    }

    //@interface UITableView (PreviousNextIndexPath)
    [Category]
    [BaseType(typeof(UITableView))]
    interface IUITableView_IQUIScrollView_Additions
    {
        //-(nullable NSIndexPath*)previousIndexPathOfIndexPath:(nonnull NSIndexPath*)indexPath;
        [NullAllowed, Export("previousIndexPathOfIndexPath")]
        NSIndexPath PreviousIndexPathOfIndexPath(NSIndexPath indexPath);
    }

    //@interface UICollectionView (PreviousNextIndexPath)
    [Category]
    [BaseType(typeof(UICollectionView))]
    interface IUICollectionView_IQUIScrollView_Additions
    {
        //-(nullable NSIndexPath*)previousIndexPathOfIndexPath:(nonnull NSIndexPath*)indexPath;
        [NullAllowed, Export("previousIndexPathOfIndexPath")]
        NSIndexPath PreviousIndexPathOfIndexPath(NSIndexPath indexPath);
    }

    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_IQUITextFieldView_Additions
    {
        /**
         To set customized distance from keyboard for textField/textView. Can't be less than zero
         */
        //@property(nonatomic, assign) CGFloat keyboardDistanceFromTextField;
        [Export("keyboardDistanceFromTextField")]
        nfloat GetKeyboardDistanceFromTextField();

        [Export("keyboardDistanceFromTextField")]
        void SetKeyboardDistanceFromTextField(nfloat value);

        /**
         If shouldIgnoreSwitchingByNextPrevious is YES then library will ignore this textField/textView while moving to other textField/textView using keyboard toolbar next previous buttons. Default is NO
         */
        //@property(nonatomic, assign) BOOL ignoreSwitchingByNextPrevious;

        // @property (assign, nonatomic) BOOL ignoreSwitchingByNextPrevious;
        [Export("ignoreSwitchingByNextPrevious")]
        bool GetIgnoreSwitchingByNextPrevious();

        [Export("ignoreSwitchingByNextPrevious")]
        void SetIgnoreSwitchingByNextPrevious(bool value);

        ///**
        // Override Enable/disable managing distance between keyboard and textField behaviour for this particular textField.
        // */
        //@property(nonatomic, assign) IQEnableMode enableMode;
        [Export("enableMode", ArgumentSemantic.Assign)]
        IQEnableMode GetEnableMode();

        [Export("enableMode", ArgumentSemantic.Assign)]
        void SetEnableMode(IQEnableMode value);

        /**
         Override resigns Keyboard on touching outside of UITextField/View behaviour for this particular textField.
         */
        //@property(nonatomic, assign) IQEnableMode shouldResignOnTouchOutsideMode;
        [Export("shouldResignOnTouchOutsideMode", ArgumentSemantic.Assign)]
        IQEnableMode GetShouldResignOnTouchOutsideMode();

        [Export("shouldResignOnTouchOutsideMode", ArgumentSemantic.Assign)]
        void SetShouldResignOnTouchOutsideMode(IQEnableMode value);
    }

    /**
     UIView hierarchy category.
     */
    [Category]
    [BaseType(typeof(UIView))]
    interface IUIView_IQUIView_Hierarchy
    {
        ///----------------------
        /// @name viewControllers
        ///----------------------

        /**
         Returns the UIViewController object that manages the receiver.
         */
        //@property(nullable, nonatomic, readonly, strong) UIViewController* viewContainingController;
        [NullAllowed, Export("viewContainingController", ArgumentSemantic.Strong)]
        UIViewController ViewContainingController();


        /**
         Returns the topMost UIViewController object in hierarchy.
         */
        //@property(nullable, nonatomic, readonly, strong) UIViewController* topMostController;
        [NullAllowed, Export("topMostController", ArgumentSemantic.Strong)]
        UIViewController TopMostController();

        /**
         Returns the UIViewController object that is actually the parent of this object. Most of the time it's the viewController object which actually contains it, but result may be different if it's viewController is added as childViewController of another viewController.
         */
        //@property(nullable, nonatomic, readonly, strong) UIViewController* parentContainerViewController;
        [NullAllowed, Export("parentContainerViewController", ArgumentSemantic.Strong)]
        UIViewController ParentContainerViewController();


        ///-----------------------------------
        /// @name Superviews/Subviews/Siglings
        ///-----------------------------------

        /**
         Returns the superView of provided class type.

         @param classType class type of the object which is to be search in above hierarchy and return

         @param belowView view object in upper hierarchy where method should stop searching and return nil
         */

        //-(nullable __kindof UIView*)superviewOfClassType:(nonnull Class) classType;
        [Export("superviewOfClassType:")]
        [return: NullAllowed]
        UIView SuperviewOfClassType(Class classType);

        //-(nullable __kindof UIView*)superviewOfClassType:(nonnull Class) classType belowView:(nullable UIView*)belowView;
        [Export("superviewOfClassType:belowView:")]
        [return: NullAllowed]
        UIView SuperviewOfClassType(Class classType, [NullAllowed] UIView belowView);

        /**
         Returns all siblings of the receiver which canBecomeFirstResponder.
         */
        //@property(nonnull, nonatomic, readonly, copy) NSArray<__kindof UIView*>* responderSiblings;
        [Export("responderSiblings", ArgumentSemantic.Copy)]
        NSObject[] ResponderSiblings();

        /**
         Returns all deep subViews of the receiver which canBecomeFirstResponder.
         */
        //@property(nonnull, nonatomic, readonly, copy) NSArray<__kindof UIView*>* deepResponderViews;
        [Export("deepResponderViews", ArgumentSemantic.Copy)]
        NSObject[] DeepResponderViews();

        ///-------------------------
        /// @name Special TextFields
        ///-------------------------

        /**
         Returns searchBar if receiver object is UISearchBarTextField, otherwise return nil.
         */
        //@property(nullable, nonatomic, readonly) UISearchBar* textFieldSearchBar;
        [NullAllowed, Export("textFieldSearchBar")]
        UISearchBar TextFieldSearchBar();

        /**
         Returns YES if the receiver object is UIAlertSheetTextField, otherwise return NO.
         */
        //@property(nonatomic, getter= isAlertViewTextField, readonly) BOOL alertViewTextField;
        [Export("isAlertViewTextField")]
        bool IsAlertViewTextField();

        ///----------------
        /// @name Transform
        ///----------------

        /**
         Returns current view transform with respect to the 'toView'.
         */
        //-(CGAffineTransform) convertTransformToView:(nullable UIView*)toView;
        [Export("convertTransformToView:")]
        CGAffineTransform ConvertTransformToView([NullAllowed] UIView toView);

        ///-----------------
        /// @name Hierarchy
        ///-----------------

        /**
         Returns a string that represent the information about it's subview's hierarchy. You can use this method to debug the subview's positions.
         */
        //@property(nonnull, nonatomic, readonly, copy) NSString* subHierarchy;
        [Export("subHierarchy")]
        string SubHierarchy();

        /**
         Returns an string that represent the information about it's upper hierarchy. You can use this method to debug the superview's positions.
         */
        //@property(nonnull, nonatomic, readonly, copy) NSString* superHierarchy;
        [Export("superHierarchy")]
        string SuperHierarchy();

        /**
         Returns an string that represent the information about it's frame positions. You can use this method to debug self positions.
         */
        //@property(nonnull, nonatomic, readonly, copy) NSString* debugHierarchy;
        [Export("debugHierarchy")]
        string DebugHierarchy();

    }

    [Category]
    [BaseType(typeof(UIViewController))]
    interface IUIViewController_IQUIView_Hierarchy
    {
        //-(nullable UIViewController*)parentIQContainerViewController;
        [NullAllowed, Export("parentIQContainerViewController")]
        UIViewController ParentIQContainerViewController();
    }

    /**
     NSObject category to used for logging purposes
     */
    [Category]
    [BaseType(typeof(NSObject))]
    interface INSObject_IQUIView_Hierarchy
    {
        /**
         Short description for logging purpose.
         */
        //@property(nonnull, nonatomic, readonly, copy) NSString* _IQDescription;
        [Export("_IQDescription")]
        [Preserve]
        string GetIQDescription();
    }

    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface IQBarButtonItemConfiguration
    {
        //-(nonnull instancetype)initWithBarButtonSystemItem:(UIBarButtonSystemItem)barButtonSystemItem action:(nullable SEL)action;
        [Export("initWithBarButtonSystemItem:action:")]
        IntPtr Constructor(UIBarButtonSystemItem barButtonSystemItem, Selector action);

        //-(nonnull instancetype)initWithImage:(nonnull UIImage*)image action:(nullable SEL)action;
        [Export("initWithImage:action:")]
        IntPtr Constructor(UIImage image, Selector action);

        //-(nonnull instancetype)initWithTitle:(nonnull NSString*)title action:(nullable SEL)action;
        [Export("initWithTitle:action:")]
        IntPtr Constructor(string title, Selector action);


        //@property (readonly, nonatomic) UIBarButtonSystemItem barButtonSystemItem; //System Item to be used to instantiate bar button
        [Export("barButtonSystemItem")]
        UIBarButtonSystemItem GetBarButtonSystemItem();

        //@property (readonly, nonatomic, nullable) UIImage *image;    //Image to show on bar button item if it's not a system item.
        [Export("image")]
        [return: NullAllowed]
        UIImage GetImage();

        //@property (readonly, nonatomic, nullable) NSString *title; //Title to show on bar button item if it's not a system item.
        [Export("title")]
        [return: NullAllowed]
        string GetTitle();

        //@property (readonly, nonatomic, nullable) SEL action;  //action for bar button item. Usually 'doneAction:(IQBarButtonItem*)item'.
        [Export("action")]
        [return: NullAllowed]
        Selector GetAction();
    }

    [Category]
    [BaseType(typeof(UIImage))]
    interface IUIImage_IQUIView_IQKeyboardToolbar
    {
        //+(nullable UIImage*)keyboardPreviousiOS9Image;
        [NullAllowed, Export("keyboardPreviousiOS9Image")]
        UIImage GetKeyboardPreviousiOS9Image();

        //+(nullable UIImage*)keyboardNextiOS9Image;
        [NullAllowed, Export("keyboardNextiOS9Image")]
        UIImage GetKeyboardNextiOS9Image();

        //+(nullable UIImage*)keyboardPreviousiOS10Image;
        [NullAllowed, Export("keyboardPreviousiOS10Image")]
        UIImage GetKeyboardPreviousiOS10Image();

        //+(nullable UIImage*)keyboardNextiOS10Image;
        [NullAllowed, Export("keyboardNextiOS10Image")]
        UIImage GetKeyboardNextiOS10Image();

        //+(nullable UIImage*)keyboardPreviousImage;
        [NullAllowed, Export("keyboardPreviousImage")]
        UIImage GetKeyboardPreviousImage();

        //+(nullable UIImage*)keyboardNextImage;
        [NullAllowed, Export("keyboardNextImage")]
        UIImage GetKeyboardNextImage();
    }

    [Protocol]
    [BaseType(typeof(UIView))]
    interface IUIView_IQUIView_IQKeyboardToolbar
    {
        ///-------------------------
        /// @name Toolbar Title
        ///-------------------------

        /**
         IQToolbar references for better customization control.
         */
        //@property(readonly, nonatomic, nonnull) IQToolbar* keyboardToolbar;
        [Export("keyboardToolbar")]
        IQToolbar KeyboardToolbar { get; }

        /**
         If `shouldHideToolbarPlaceholder` is YES, then title will not be added to the toolbar. Default to NO.
         */
        //@property(assign, nonatomic) BOOL shouldHideToolbarPlaceholder;
        [Export("shouldHideToolbarPlaceholder")]
        bool ShouldHideToolbarPlaceholder { get; set; }

        /**
         `toolbarPlaceholder` to override default `placeholder` text when drawing text on toolbar.
         */
        //@property(nullable, strong, nonatomic) NSString* toolbarPlaceholder;
        [NullAllowed, Export("toolbarPlaceholder", ArgumentSemantic.Strong)]
        string ToolbarPlaceholder { get; set; }

        /**
         `drawingToolbarPlaceholder` will be actual text used to draw on toolbar. This would either `placeholder` or `toolbarPlaceholder`.
         */
        //@property(nullable, strong, nonatomic, readonly) NSString* drawingToolbarPlaceholder;
        [NullAllowed, Export("drawingToolbarPlaceholder", ArgumentSemantic.Strong)]
        string DrawingToolbarPlaceholder { get; }

        ///-------------
        /// MARK: Common
        ///-------------

        ////- (void)addKeyboardToolbarWithTarget:(nullable id)target titleText:(nullable NSString*)titleText rightBarButtonConfiguration:(nullable IQBarButtonItemConfiguration*)rightBarButtonConfiguration previousBarButtonConfiguration:(nullable IQBarButtonItemConfiguration*)previousBarButtonConfiguration nextBarButtonConfiguration:(nullable IQBarButtonItemConfiguration*)nextBarButtonConfiguration;
        [Export("addKeyboardToolbarWithTarget:titleText:rightBarButtonConfiguration:previousBarButtonConfiguration:nextBarButtonConfiguration")]
        void AddKeyboardToolbarWithTarget([NullAllowed] string title, [NullAllowed] IQBarButtonItemConfiguration rightBarButtonConfiguration, [NullAllowed] IQBarButtonItemConfiguration previousBarButtonConfiguration, [NullAllowed] IQBarButtonItemConfiguration nextBarButtonConfiguration);

        ///------------
        /// @name Done
        ///------------

        //- (void)addDoneOnKeyboardWithTarget:(nullable id)target action:(nullable SEL)action;
        [Export("addDoneOnKeyboardWithTarget:action:")]
        void AddDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector action);

        //- (void)addDoneOnKeyboardWithTarget:(nullable id)target action:(nullable SEL)action shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addDoneOnKeyboardWithTarget:action:shouldShowPlaceholder:")]
        void AddDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector action, bool shouldShowPlaceholder);

        //- (void)addDoneOnKeyboardWithTarget:(nullable id)target action:(nullable SEL)action titleText:(nullable NSString*)titleText;
        [Export("addDoneOnKeyboardWithTarget:action:titleText:")]
        void AddDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector action, [NullAllowed] string titleText);


        ///------------
        /// @name Right
        ///------------


        //- (void) addRightButtonOnKeyboardWithText:(nullable NSString*)text target:(nullable id) target action:(nullable SEL) action;
        [Export("addRightButtonOnKeyboardWithText:target:action:")]
        void AddRightButtonOnKeyboardWithText([NullAllowed] string text, [NullAllowed] NSObject target, [NullAllowed] Selector action);

        //- (void)addRightButtonOnKeyboardWithText:(nullable NSString*)text target:(nullable id)target action:(nullable SEL)action shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addRightButtonOnKeyboardWithText:target:action:shouldShowPlaceholder:")]
        void AddRightButtonOnKeyboardWithText([NullAllowed] string text, [NullAllowed] NSObject target, [NullAllowed] Selector action, bool shouldShowPlaceholder);

        //- (void)addRightButtonOnKeyboardWithText:(nullable NSString*)text target:(nullable id)target action:(nullable SEL)action titleText:(nullable NSString*)titleText;
        [Export("addRightButtonOnKeyboardWithText:target:action:titleText:")]
        void AddRightButtonOnKeyboardWithText([NullAllowed] string text, [NullAllowed] NSObject target, [NullAllowed] Selector action, [NullAllowed] string titleText);


        //- (void) addRightButtonOnKeyboardWithImage:(nullable UIImage*)image target:(nullable id) target action:(nullable SEL) action;
        [Export("addRightButtonOnKeyboardWithImage:target:action:")]
        void AddRightButtonOnKeyboardWithImage([NullAllowed] UIImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action);

        //- (void)addRightButtonOnKeyboardWithImage:(nullable UIImage*)image target:(nullable id)target action:(nullable SEL)action shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addRightButtonOnKeyboardWithImage:target:action:shouldShowPlaceholder:")]
        void AddRightButtonOnKeyboardWithImage([NullAllowed] UIImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action, bool shouldShowPlaceholder);

        //- (void)addRightButtonOnKeyboardWithImage:(nullable UIImage*)image target:(nullable id)target action:(nullable SEL)action titleText:(nullable NSString*)titleText;
        [Export("addRightButtonOnKeyboardWithImage:target:action:titleText:")]
        void AddRightButtonOnKeyboardWithImage([NullAllowed] UIImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action, [NullAllowed] string titleText);



        ///------------------
        /// @name Cancel/Done
        ///------------------


        //- (void)addCancelDoneOnKeyboardWithTarget:(nullable id)target cancelAction:(nullable SEL)cancelAction doneAction:(nullable SEL)doneAction;
        [Export("addCancelDoneOnKeyboardWithTarget:cancelAction:doneAction:")]
        void AddCancelDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector cancelAction, [NullAllowed] Selector doneAction);

        //- (void)addCancelDoneOnKeyboardWithTarget:(nullable id)target cancelAction:(nullable SEL)cancelAction doneAction:(nullable SEL)doneAction shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addCancelDoneOnKeyboardWithTarget:cancelAction:doneAction:shouldShowPlaceholder:")]
        void AddCancelDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector cancelAction, [NullAllowed] Selector doneAction, bool shouldShowPlaceholder);

        //- (void)addCancelDoneOnKeyboardWithTarget:(nullable id)target cancelAction:(nullable SEL)cancelAction doneAction:(nullable SEL)doneAction titleText:(nullable NSString*)titleText;
        [Export("addCancelDoneOnKeyboardWithTarget:cancelAction:doneAction:titleText:")]
        void AddCancelDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector cancelAction, [NullAllowed] Selector doneAction, [NullAllowed] string titleText);


        ///-----------------
        /// @name Right/Left
        ///-----------------


        //- (void)addLeftRightOnKeyboardWithTarget:(nullable id)target leftButtonTitle:(nullable NSString*)leftButtonTitle rightButtonTitle:(nullable NSString*)rightButtonTitle leftButtonAction:(nullable SEL)leftButtonAction rightButtonAction:(nullable SEL)rightButtonAction;
        [Export("addLeftRightOnKeyboardWithTarget:leftButtonTitle:rightButtonTitle:leftButtonAction:rightButtonAction:")]
        void AddLeftRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] string leftButtonTitle, [NullAllowed] string rightButtonTitle, [NullAllowed] Selector leftButtonAction, [NullAllowed] Selector rightButtonAction);

        //- (void)addLeftRightOnKeyboardWithTarget:(nullable id)target leftButtonTitle:(nullable NSString*)leftButtonTitle rightButtonTitle:(nullable NSString*)rightButtonTitle leftButtonAction:(nullable SEL)leftButtonAction rightButtonAction:(nullable SEL)rightButtonAction shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addLeftRightOnKeyboardWithTarget:leftButtonTitle:rightButtonTitle:leftButtonAction:rightButtonAction:shouldShowPlaceholder:")]
        void AddLeftRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] string leftButtonTitle, [NullAllowed] string rightButtonTitle, [NullAllowed] Selector leftButtonAction, [NullAllowed] Selector rightButtonAction, bool shouldShowPlaceholder);

        //- (void)addLeftRightOnKeyboardWithTarget:(nullable id)target leftButtonTitle:(nullable NSString*)leftButtonTitle rightButtonTitle:(nullable NSString*)rightButtonTitle leftButtonAction:(nullable SEL)leftButtonAction rightButtonAction:(nullable SEL)rightButtonAction titleText:(nullable NSString*)titleText;
        [Export("addLeftRightOnKeyboardWithTarget:leftButtonTitle:rightButtonTitle:leftButtonAction:rightButtonAction:titleText:")]
        void AddLeftRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] string leftButtonTitle, [NullAllowed] string rightButtonTitle, [NullAllowed] Selector leftButtonAction, [NullAllowed] Selector rightButtonAction, [NullAllowed] string titleText);


        ///-------------------------
        /// @name Previous/Next/Done
        ///-------------------------


        //- (void)addPreviousNextDoneOnKeyboardWithTarget:(nullable id)target previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction doneAction:(nullable SEL)doneAction;
        [Export("addPreviousNextDoneOnKeyboardWithTarget:previousAction:nextAction:doneAction:")]
        void AddPreviousNextDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector doneAction);

        //- (void)addPreviousNextDoneOnKeyboardWithTarget:(nullable id)target previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction doneAction:(nullable SEL)doneAction shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addPreviousNextDoneOnKeyboardWithTarget:previousAction:nextAction:doneAction:shouldShowPlaceholder:")]
        void AddPreviousNextDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector doneAction, bool shouldShowPlaceholder);

        //- (void)addPreviousNextDoneOnKeyboardWithTarget:(nullable id)target previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction doneAction:(nullable SEL)doneAction titleText:(nullable NSString*)titleText;
        [Export("addPreviousNextDoneOnKeyboardWithTarget:previousAction:nextAction:doneAction:titleText:")]
        void AddPreviousNextDoneOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector doneAction, [NullAllowed] string titleText);


        ///--------------------------
        /// @name Previous/Next/Right
        ///--------------------------


        //- (void)addPreviousNextRightOnKeyboardWithTarget:(nullable id)target rightButtonTitle:(nullable NSString*)rightButtonTitle previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction rightButtonAction:(nullable SEL)rightButtonAction;
        [Export("addPreviousNextRightOnKeyboardWithTarget:rightButtonTitle:previousAction:nextAction:rightButtonAction:")]
        void AddPreviousNextRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] string rightButtonTitle, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector rightButtonAction);

        //- (void)addPreviousNextRightOnKeyboardWithTarget:(nullable id)target rightButtonTitle:(nullable NSString*)rightButtonTitle previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction rightButtonAction:(nullable SEL)rightButtonAction shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addPreviousNextRightOnKeyboardWithTarget:rightButtonTitle:previousAction:nextAction:rightButtonAction:shouldShowPlaceholder:")]
        void AddPreviousNextRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] string rightButtonTitle, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector rightButtonAction, bool shouldShowPlaceholder);

        //- (void)addPreviousNextRightOnKeyboardWithTarget:(nullable id)target rightButtonTitle:(nullable NSString*)rightButtonTitle previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction rightButtonAction:(nullable SEL)rightButtonAction titleText:(nullable NSString*)titleText;
        [Export("addPreviousNextRightOnKeyboardWithTarget:rightButtonTitle:previousAction:nextAction:rightButtonAction:titleText:")]
        void AddPreviousNextRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] string rightButtonTitle, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector rightButtonAction, [NullAllowed] string titleText);


        //- (void) addPreviousNextRightOnKeyboardWithTarget:(nullable id) target rightButtonImage:(nullable UIImage*)rightButtonImage previousAction:(nullable SEL) previousAction nextAction:(nullable SEL) nextAction rightButtonAction:(nullable SEL) rightButtonAction;
        [Export("addPreviousNextRightOnKeyboardWithTarget:rightButtonImage:previousAction:nextAction:rightButtonAction:")]
        void AddPreviousNextRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] UIImage rightButtonImage, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector rightButtonAction);

        //- (void)addPreviousNextRightOnKeyboardWithTarget:(nullable id)target rightButtonImage:(nullable UIImage*)rightButtonImage previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction rightButtonAction:(nullable SEL)rightButtonAction shouldShowPlaceholder:(BOOL)shouldShowPlaceholder;
        [Export("addPreviousNextRightOnKeyboardWithTarget:rightButtonImage:previousAction:nextAction:rightButtonAction:shouldShowPlaceholder:")]
        void AddPreviousNextRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] UIImage rightButtonImage, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector rightButtonAction, bool shouldShowPlaceholder);

        //- (void)addPreviousNextRightOnKeyboardWithTarget:(nullable id)target rightButtonImage:(nullable UIImage*)rightButtonImage previousAction:(nullable SEL)previousAction nextAction:(nullable SEL)nextAction rightButtonAction:(nullable SEL)rightButtonAction titleText:(nullable NSString*)titleText;
        [Export("addPreviousNextRightOnKeyboardWithTarget:rightButtonImage:previousAction:nextAction:rightButtonAction:titleText:")]
        void AddPreviousNextRightOnKeyboardWithTarget([NullAllowed] NSObject target, [NullAllowed] UIImage rightButtonImage, [NullAllowed] Selector previousAction, [NullAllowed] Selector nextAction, [NullAllowed] Selector rightButtonAction, [NullAllowed] string titleText);
    }
}