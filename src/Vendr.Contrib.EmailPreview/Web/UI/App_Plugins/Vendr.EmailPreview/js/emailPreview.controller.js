(function () {

    'use strict';

    angular.module('vendr')
        .controller('Vendr.EmailPreviewController',
            function ($scope, $timeout, umbRequestHelper) {

                var vm = this;

                vm.init = function () {
                    if ($scope.model.context) {
                        vm.storeId = $scope.model.context.storeId;
                        vm.templateId = $scope.model.context.templateId;
                        vm.culture = $scope.model.context.culture;
                    }
                };

                vm.loadPreview = function (storeId, templateId, orderId, culture) {
                    vm.loading = true;
                    vm.view = '/umbraco/backoffice/vendr/EmailPreview/RenderPreview?' + umbRequestHelper.dictionaryToQueryString({
                        storeId: storeId,
                        templateId: templateId,
                        orderId: orderId,
                        culture: culture
                    });
                };

                vm.close = function () {
                    if ($scope.model.close) {
                        $scope.model.close();
                    }
                };

                vm.init();

                $scope.$on('$includeContentLoaded', function () {
                    vm.loading = false;
                });

                $timeout(function () {
                    $('.vendr-search__input').unbind('typeahead:selected');

                    $('.vendr-search__input').unbind('typeahead:autocompleted');

                    $(document).on('typeahead:selected', '.vendr-search__input', function (e, data) {
                        vm.loadPreview(data.storeId, vm.templateId, data.id, vm.culture);
                    });

                    $(document).on('typeahead:autocompleted', '.vendr-search__input', function (e, data) {
                        vm.loadPreview(data.storeId, vm.templateId, data.id, vm.culture);
                    });
                }, 500);

            });

}());