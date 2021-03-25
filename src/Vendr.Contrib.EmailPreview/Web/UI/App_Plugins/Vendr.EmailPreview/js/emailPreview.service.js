(function () {

    'use strict';

    angular.module('vendr')
        .factory('vendrEmailPreviewService',
            function (editorService) {
                return {
                    openDialog: function (node) {
                        var dialog = {
                            title: 'Preview',
                            view: '/App_Plugins/Vendr.EmailPreview/views/preview.html',
                            size: 'medium',
                            context: {
                                storeId: node.entity.metaData.storeId,
                                templateId: node.entity.id,
                                culture: node.entity.metaData.culture
                            },
                            close: function () {
                                editorService.close();
                            }
                        };
                        editorService.open(dialog);
                    }
                }
            });

}());