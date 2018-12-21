define([
    // dojo
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/dom-construct",

    // dijit
    "dijit/_Widget",
    "dijit/_TemplatedMixin",

    // dgrid
    "dgrid/OnDemandGrid",
    "dgrid/Selection",

    // epi
    "epi/dependency",
    "epi/shell/dgrid/util/misc",

    // epi-cms
    "epi-cms/dgrid/formatters",

    // resources
    "dojo/text!./templates/GoalManager.html",
    "epi/i18n!epi/nls/episerver.shared",
    "epi/i18n!epi/nls/episerver.goal"
], function (
    // dojo
    array,
    declare,
    domConstruct,

    // dijit
    _Widget,
    _TemplatedMixin,

    // dgrid
    OnDemandGrid,
    Selection,

    // epi
    dependency,
    shellMisc,

    // epi-cms
    formatters,

    // resources
    templateString,
    sharedResources,
    resources
) {
    return declare([_Widget, _TemplatedMixin], {

        resources: resources,

        templateString: templateString,

        store: null,

        grid: null,

        // _noDataMessage: string
        //      String to notify that the grid content is empty.
        _noDataMessage: '<span><span class="dijitReset dijitInline">' + resources.nodatamessage + '</span></span>',

        postCreate: function () {
            this.inherited(arguments);
            this.store = this.store || dependency.resolve("epi.storeregistry").get("epi.goal");
            this._setupGrid();
        },

        _setupGrid: function () {
            var gridType = declare([OnDemandGrid, Selection]);
            var columns = this._getColumns();
            this.grid = new gridType({
                selectionMode: "single",
                noDataMessage: this._noDataMessage,
                columns: columns,
                store: this.store,
                className: "epi-plain-grid epi-plain-grid-modal epi-plain-grid--margin-bottom epi-grid-height--auto"
            });
            this.grid.set("query", {});
            this.own(this.grid);
            domConstruct.place(this.grid.domNode, this.gridNode);
        },

        _getColumns: function(){
            var columns = {
                name: {
                    label:sharedResources.header.name,
                    sortable: false
                },
                type: {
                    label: "Type",
                    sortable: false
                }
            };
            return columns;
        }
    });
});