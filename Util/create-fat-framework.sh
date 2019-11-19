!/bin/bash

echo "Defining variables"
BUILD_DIR="/Users/eduardoappolinario/C/Build/IQKeyboardManager"
CONFIGURATION="Release"
PROJECT_NAME="IQKeyboardManager.xcodeproj"
PRODUCT_NAME="IQKeyboardManager"

UNIVERSAL_OUTPUT_FOLDER="${BUILD_DIR}/${CONFIGURATION}-universal"
UNIVERSAL_OUTPUT_FRAMEWORK="${UNIVERSAL_OUTPUT_FOLDER}/${PRODUCT_NAME}.framework"
UNIVERSAL_OUTPUT_BINARY="${UNIVERSAL_OUTPUT_FRAMEWORK}/${PRODUCT_NAME}"

IPHONE_OS_FOLDER="${BUILD_DIR}/${CONFIGURATION}-iphoneos"
IPHONE_OS_FRAMEWORK="/${IPHONE_OS_FOLDER}/${PRODUCT_NAME}.framework"
IPHONE_OS_BINARY="${IPHONE_OS_FRAMEWORK}/${PRODUCT_NAME}"

IPHONE_SIMULATOR_FOLDER="${BUILD_DIR}/${CONFIGURATION}-iphonesimulator"
IPHONE_SIMULATOR_FRAMEWORK="${IPHONE_SIMULATOR_FOLDER}/${PRODUCT_NAME}.framework"
IPHONE_SIMULATOR_BINARY="${IPHONE_SIMULATOR_FRAMEWORK}/${PRODUCT_NAME}"

echo "Making sure the output directories exists"
mkdir -p "${BUILD_DIR}"
mkdir -p "${UNIVERSAL_OUTPUT_FOLDER}"
mkdir -p "${UNIVERSAL_OUTPUT_FRAMEWORK}"

echo " Build Device and Simulator versions"
xcodebuild -project "${PROJECT_NAME}" ONLY_ACTIVE_ARCH=NO OTHER_CFLAGS="-fembed-bitcode" -configuration ${CONFIGURATION} BUILD_DIR="${BUILD_DIR}" clean build -sdk iphoneos
xcodebuild -project "${PROJECT_NAME}" ONLY_ACTIVE_ARCH=NO OTHER_CFLAGS="-fembed-bitcode" -configuration ${CONFIGURATION} BUILD_DIR="${BUILD_DIR}" clean build -sdk iphonesimulator

echo "Copy the framework structure (from iPhone OS build) to the universal folder"
cp -R "${IPHONE_OS_FRAMEWORK}" "${UNIVERSAL_OUTPUT_FOLDER}"

echo "Step 6. Convenience step to open the project's directory in Finder"
open "${UNIVERSAL_OUTPUT_FOLDER}"