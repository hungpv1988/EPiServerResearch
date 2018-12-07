define([
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/Stateful",
    "dijit/Destroyable",
    "epi-cms/contentediting/command/BlockRemove",
    "epi-cms/contentediting/command/BlockEdit",
    "epi-cms/contentediting/command/MoveVisibleToPrevious",
    "epi-cms/contentediting/command/MoveVisibleToNext",
    "epi-cms/contentediting/command/Personalize",
    "epi-cms/contentediting/command/SelectDisplayOption",

    "alloy/command/SelectStrategy"
], function (array, declare, Stateful, Destroyable, Remove, Edit, MoveVisibleToPrevious, MoveVisibleToNext, Personalize, SelectDisplayOption, SelectStrategy) {

    return declare([Stateful, Destroyable], {
        // tags:
        //      internal

        commands: null,

        constructor: function () {
            this.commands = [
                new Edit(),
                new SelectDisplayOption(),
                new SelectStrategy(),
                new Personalize(),
                new MoveVisibleToPrevious(),
                new MoveVisibleToNext(),
                new Remove()
            ];

            this.commands.forEach(function (command) {
                this.own(command);
            }, this);
        },

        _modelSetter: function (model) {
            this.model = model;

            array.forEach(this.commands, function (command) {
                command.set("model", model);
            });
        }
    });
});
