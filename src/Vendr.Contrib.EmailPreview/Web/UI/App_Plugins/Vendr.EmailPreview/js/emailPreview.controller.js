(function () {

    'use strict';

    angular.module('vendr')
        .controller('Vendr.EmailPreviewController',
            function ($scope, umbRequestHelper) {

                var vm = this;

                vm.init = function () {
                    if ($scope.model.context) {
                        vm.storeId = $scope.model.context.storeId;
                        vm.templateId = $scope.model.context.templateId;
                        vm.culture = $scope.model.context.culture;
                    }

                    vm.loadPreview(data.storeId, vm.templateId, vm.orderId, vm.culture);
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

            });

}());