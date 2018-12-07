define([
    // General application modules
    "dojo/_base/declare",
    "dojo/_base/lang",
    "dojo/when",

    "epi/dependency",

    "epi-cms/contentediting/command/_ContentAreaCommand",
    "epi-cms/contentediting/viewmodel/ContentBlockViewModel",

    "alloy/widget/StrategySelector",

    // Resources
    "epi/i18n!epi/cms/nls/episerver.cms.contentediting.editors.contentarea.displayoptions"
], function (declare, lang, when, dependency, _ContentAreaCommand, ContentBlockViewModel, StrategySelector, resources) {

    return declare([_ContentAreaCommand], {
        // tags:
        //      internal

        // label: [public] String
        //      The action text of the command to be used in visual elements.
        label: "Content Strategy",

        // category: [readonly] String
        //      A category which hints that this item should be displayed as an popup menu.
        category: "popup",

        _labelAutomatic: lang.replace(resources.label, [resources.automatic]),

        constructor: function () {
            this.popup = new StrategySelector();
        },

        postscript: function () {
            this.inherited(arguments);

            if (!this.store) {
                // get default display options  for layout (widhth, height)  -> be removed later on in strategyblock
                var registry = dependency.resolve("epi.storeregistry");
                this.store = registry.get("epi.cms.displayoptions");
            }

            // really no need for this segmeent because popup will reset its displayoptions after model is set.
            when(this.store.get(), lang.hitch(this, function (options) {
                // Reset command's available property in order to reset dom's display property of the given node
                this._setCommandAvailable(options);

                this.popup.set("displayOptions", options);
            }));
        },

        destroy: function () {
            this.inherited(arguments);

            this.popup && this.popup.destroyRecursive();
        },

        _onModelChange: function () {
            // summary:
            //      Updates canExecute after the model value has changed.
            // tags:
            //      protected

            this.inherited(arguments);

            this.popup.set("model", this.model);

            // model has changed, so should re-check this.
            this._setCommandAvailable(this.popup.displayOptions);
        },

        _setCommandAvailable: function (/*Array*/displayOptions) {
            // summary:
            //      Set command available
            // displayOptions: [Array]
            //      Collection of a content display mode
            // tags:
            //      private

            this.set("isAvailable", displayOptions && displayOptions.length > 0 && this.model instanceof ContentBlockViewModel);
        },

        _setLabel: function (displayOption) {
            when(this.store.get(displayOption), lang.hitch(this, function (option) {
                this.set("label", lang.replace(resources.label, [option.name]));

            }), lang.hitch(this, function (error) {

                console.log("Could not get the option for: ", displayOption, error);

                this.set("label", this._labelAutomatic);
            }));
        },

        _onModelValueChange: function () {
            this.set("canExecute", !!this.model && this.model.contentLink && !this.model.get("readOnly"));
        }
    });
});
