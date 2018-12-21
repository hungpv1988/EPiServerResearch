define([
// dojo
    "dojo/_base/declare",
// dijit
    "dijit/_TemplatedMixin",
    "dijit/_WidgetBase",
//template
    "dojo/text!./templates/GoalNavigation.html",
// Resources
    "epi/i18n!epi/cms/nls/commerce.widget.settings"
],

function (
// dojo
    declare,
// dijit
    _TemplatedMixin,
    _WidgetBase,
//template
    template,
// Resources
    resources
) {
    // module:
    //      epi-ecf-ui.widget.Settings

    return declare([_WidgetBase, _TemplatedMixin], {
        // summary:
        //      Settings widget.
        // tags:
        //      public

        templateString: template,

        resources: resources,

        baseUrl: null,

        location: null,

        postMixInProperties: function(){
            this.inherited(arguments);
            this.baseUrl = this.baseUrl || this.constructUrl();
        },

        constructUrl: function(){
            var location = this.location || window.top.location;
            var host = location.protocol + "//" + location.hostname;
            if (location.port){
                host = host + ":" + location.port;
            }
            return host + location.pathname;
        }
    });
});