define([
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/_base/lang",
    "dojo/when",

    "dijit/MenuSeparator",

    "epi/shell/DestroyableByKey",
    "epi-cms/widget/SelectorMenuBase",

    // Resouces
    "epi/i18n!epi/cms/nls/episerver.cms.contentediting.editors.contentarea.displayoptions",

    // Widgets used in template
    "epi/shell/widget/RadioMenuItem"
], function (
    array,
    declare,
    lang,
    when,

    MenuSeparator,

    DestroyableByKey,
    SelectorMenuBase,

    // Resouces
    resources,

    RadioMenuItem
) {

    return declare([SelectorMenuBase, DestroyableByKey], {
        // summary:
        //      Used for selecting display options for a block in a content area
        //
        // tags:
        //      internal

        // model: [public] epi-cms/contentediting/viewmodel/ContentBlockViewModel
        //      View model for the selector
        model: null,

        // _resources: [private] Object
        //      Resource object used in the template
        headingText: "Select a Strategy",

        _rdAutomatic: null,
        _separator: null,

        postCreate: function () {
            // summary:
            //      Create the selector template and query for display options

            this.inherited(arguments);
            // this._setup();
        },

        destroy: function () {
            this.inherited(arguments);
        },

        _restoreDefault: function () {
            this.model.modify(function () {
                this.model.set("displayOption", null);
            }, this);
        },

        _setModelAttr: function (model) {
            this._set("model", model);

            this._setup();
        },

        _setDisplayOptionsAttr: function (displayOptions) {
            this._set("displayOptions", displayOptions);
        },

        _setup: function () {

            this._removeMenuItems();

            // var selectedDisplayOption = this.model.get("displayOption");

            //new Strategy()
            //{
            //    Name = "A",
            //    Id = Guid.Parse("b5b2d5f9-bcd1-4ec6-8f15-dc730411371c")
            //},

            //new Strategy()
            //{
            //    Name = "B",
            //    Id = Guid.Parse("b5b2d5f9-bcd1-4ec6-8f15-dc730411382d")
            //},

            //new Strategy()
            //{
            //    Name = "C",
            //    Id = Guid.Parse("b5b2d5f9-bcd1-4ec6-8f15-cd820411382d")
            //}
            this.displayOptions = [
                {
                    name: "A",
                    title: "A",
                    id : 1
                },

                {
                    name: "B",
                    title: "B",
                    id: 2
                },

                {
                    name: "C",
                    title: "C",
                    id: 3
                }
            ];

            var self = this;

            array.forEach(this.displayOptions, function (displayOption) {

                var item = new RadioMenuItem({
                    label: displayOption.name,
                    iconClass: displayOption.iconClass,
                    displayOptionId: displayOption.id,
                    checked: this.model.attributes["data-strategy"] == displayOption.id,
                    title: displayOption.description
                });

                this.ownByKey("items", item.watch("checked", lang.hitch(this, function (property, oldValue, newValue) {
                    if (!newValue) {
                        return;
                    }

                    this.model.modify(function () {
                        this.model.attributes["data-strategy"] = displayOption.id;
                    }, this, true);
                })));

                this.addChild(item);

            }, this);
        },

        _removeMenuItems: function () {
            var items = this.getChildren();
            this.destroyByKey("items");
            items.forEach(function (item) {
                if (item === this._rdAutomatic || item === this._separator) {
                    return;
                }
                this.removeChild(item);
                item.destroy();
            }, this);
        }
    });
});
