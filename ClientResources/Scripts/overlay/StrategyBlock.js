define([
    // Dojo
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/_base/lang",

    "epi-cms/widget/overlay/Block",
    "alloy/command/ContentAreaWithStrateryCommands"
], function (
    // Dojo
    array,
    declare,
    lang,

    Block,
    ContentAreaWithStrateryCommands
) {

    return declare([Block], {

        postMixInProperties: function () {

            this.inherited(arguments);

            this.own(
                this.commandProvider = this.commandProvider || new ContentAreaWithStrateryCommands({ model: this.viewModel })
            );
        }
    });
});